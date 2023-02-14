using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

using BnsBinTool.Core.DataStructs;

using HZH_Controls;

using Xylia.Extension;
using Xylia.Preview.Common.Interface.RecordAttribute;
using Xylia.Preview.Data.Helper;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Data.Table.XmlRecord;
using Xylia.Preview.Properties;

namespace Xylia.Preview.Data
{
	/// <summary>
	/// 数据表
	/// </summary>
	public class DataTable<T> : IEnumerable<T>, IEnumerable where T : BaseRecord, new()
	{
		#region 构造
		public DataTableSet DataTableSet;

		public string TypeName = typeof(T).Name;
		#endregion

		#region 字段
		/// <summary>
		/// 显示调试信息
		/// </summary>
		public bool ShowDebugInfo { get; set; } = true;

		public string XmlDataPath;
		#endregion


		#region 数据处理
		protected readonly Dictionary<Ref, Lazy<T>> ByRef = new();

		protected readonly Dictionary<string, Ref> ByAlias = new(StringComparer.OrdinalIgnoreCase);


		private Lazy<T>[] _data;

		public Lazy<T>[] Data
		{
			private set => this._data = value;
			get
			{
				this.Load();
				return this._data;
			}
		}
		#endregion



		#region 加载方法
		protected bool LoadFromGame => CommonPath.DataLoadMode;

		/// <summary>
		/// 尝试载入数据
		/// 用于需要事先载入数据的场景
		/// </summary>
		public void TryLoad() => this.Load();



		/// <summary>
		/// 正在加载状态中
		/// </summary>
		private bool InLoading = false;

		/// <summary>
		/// 加载资源
		/// </summary>
		/// <param name="Reload">指示在存在数据时，是否可以重新加载</param>
		private void Load(bool Reload = false)
		{
			#region 初始化
			//正在加载状态，等待到数据加载完成
			if (this.InLoading)
			{
				//等待到加载完成，所以要注意这个等待标志值不能发生异常
				//可能的异常原因：结束后不解除标志、在同一线程上多次请求加载
				while (this.InLoading) Thread.Sleep(100);
				return;
			}

			//有数据且不需要重载，则不进行处理
			if (this._data != null && !Reload) return;


			//如果是设计器模式，则不进行处理
			if (Program.IsDesignMode) return;
			#endregion


			//进入加载状态
			this.InLoading = true;
			this._data = null;

			lock (this)
			{
				var task = new Task(() =>
				{
					try
					{
						if (!LoadFromGame) this.LoadXml();
						else this.LoadData();

						InLoading = false;
						Trace.WriteLine($"[{ DateTime.Now }] 完成信息载入: { TypeName } ({ this._data.Length }项)");
					}
					catch (Exception ex)
					{
						//载入失败的处理
						this._data = Array.Empty<Lazy<T>>();

						InLoading = false;
						Trace.WriteLine($"[{ DateTime.Now }] 加载失败: { TypeName } -> {ex}");
					}
				});

				task.Start();
				task.Wait();
			}
		}

		/// <summary>
		/// 加载外部配置文件
		/// </summary>
		/// <exception cref="FileNotFoundException"></exception>
		private void LoadXml()
		{
			var Files = new DirectoryInfo(CommonPath.WorkingDirectory).GetFiles(TypeName + "Data*");
			if (!Files.Any()) throw new FileNotFoundException("数据不存在");



			var objs = Files.SelectMany(o => o.FullName.GetXmlDocument().DocumentElement.ChildNodes.OfType<XmlElement>()).ToArray();

			this._data = new Lazy<T>[objs.Length];
			for (var x = 0; x < this._data.Length; x++)
			{
				int index = x;
				var record = objs[index];
				var o = this._data[index] = new(() =>
				{
					var Object = new T();
					Object.TableIndex = (uint)index;
					Object.LoadData(record);

					return Object;
				});


				if (!int.TryParse(record.Attributes["id"]?.Value, out int RecordId)) RecordId = index + 1;

				var Ref = new Ref(RecordId);
				this.ByRef[Ref] = o;

				string alias = record.Attributes["alias"]?.Value;
				if (alias != null) this.ByAlias[alias] = Ref;
			}
		}

		/// <summary>
		/// 加载游戏数据
		/// </summary>
		/// <exception cref="FileNotFoundException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		private void LoadData()
		{
			if (LoadFromGame)
				lock (DataTableSet) DataTableSet.LoadData(XmlDataPath is null);

			//获取数据结构
			var helper = DataTableSet.GetHelper(TypeName, false);


			if (XmlDataPath != null)
			{
				uint TableIndex = 0;
				List<T> tables = DataTableSet.XmlData
					.EnumerateFiles(XmlDataPath)
					.SelectMany(o =>
					{
						o.Decrypt();
						return o.Xml.Nodes.ReadFile<T>(ref TableIndex);
					})
					.ToList();


				this._data = new Lazy<T>[tables.Count];
				for (var x = 0; x < this._data.Length; x++)
				{
					var data = tables[x];
					var Ref = new Ref(data.Key());

					this.ByRef[Ref] = this._data[x] = new(data);
					if (data.alias != null) this.ByAlias[data.alias] = Ref;
				}
			}
			else
			{
				ArgumentNullException.ThrowIfNull(helper);

				//获取数据表
				if (helper.Definition is null || helper.Definition.Type == 0) throw new Exception(TypeName + " 数据对象失败");
				var Table = DataTableSet.Tables.FirstOrDefault(table => table.Type == helper.Definition.Type);
				ArgumentNullException.ThrowIfNull(Table);

				//校验版本信息
				helper.CheckVersion(Table);
				_processTable += new ProcessTableHandle((o) => DataTableSet.datafileToXml.ProcessTable(Table, helper.Definition, o));


				if (CommonPath.Test == 1 && this.DataTableSet is not LocalDataTableSet)
					ProcessTable(CommonPath.WorkingDirectory);


				var attrDef = helper.GetAttrDef();

				this._data = new Lazy<T>[Table.Records.Count];
				for (var x = 0; x < this._data.Length; x++)
				{
					int index = x;
					var data = Table.Records[index];
					if (data is null) continue;

					var o = this._data[index] = new(() =>
					{
						var Object = new T();
						Object.TableIndex = (uint)index;
						Object.LoadData(new DbData(DataTableSet.datafileToXml, attrDef, data));

						return Object;
					});

					this.ByRef[new Ref(data.RecordId, data.RecordVariationId)] = o;
				}


				if (helper.Aliases != null)
					foreach (var o in helper.Aliases)
						this.ByAlias[o.Alias] = new Ref((int)o.MainID, (int)o.Variation);
			}
		}
		#endregion

		#region 获取对象信息
		public T this[string Alias] => this.GetLazyInfo(Alias)?.Value;

		public T this[int Id, int Variant = 0] => this.GetLazyInfo(new Ref(Id, Variant))?.Value;

		public T this[BaseRecord resolvedRecord] => this[resolvedRecord?.alias];


		protected Lazy<T> GetLazyInfo(string Alias)
		{
			if (string.IsNullOrWhiteSpace(Alias)) return null;
			else if (Alias.Contains(':'))
			{
				var o = Alias.Split(':');
				return GetLazyInfo(new Ref(o[0].ToInt(), o[1].ToInt()));
			}
			else if (int.TryParse(Alias, out var MainID)) return GetLazyInfo(new Ref(MainID));


			this.TryLoad();
			if (this.ByAlias.TryGetValue(Alias, out var item)) return GetLazyInfo(item);
			if (this._data.Length != 0 && ShowDebugInfo) Debug.WriteLine($"[{ TypeName }] 对象获取失败  alias: {Alias}");
			return null;
		}

		protected Lazy<T> GetLazyInfo(Ref Ref)
		{
			if (Ref.Id <= 0) return null;


			this.TryLoad();
			if (this.ByRef.TryGetValue(Ref, out var item)) return item;
			if (this._data.Length != 0) Debug.WriteLine($"[{ TypeName }] 对象获取失败  id: {Ref.Id} variation: {Ref.Variant}");
			return null;
		}
		#endregion



		#region 处理类方法
		public void ProcessTable(string _outputPath) => this._processTable?.Invoke(_outputPath);

		private delegate void ProcessTableHandle(string _outputPath);

		private event ProcessTableHandle _processTable;
		#endregion

		#region 接口方法
		/// <summary>
		/// 清除数据
		/// </summary>
		public void Clear()
		{
			this._data = null;

			this.ByRef.Clear();
			this.ByAlias.Clear();
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (var info in this.Data)
				yield return info.Value;

			yield break;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		#endregion
	}
}