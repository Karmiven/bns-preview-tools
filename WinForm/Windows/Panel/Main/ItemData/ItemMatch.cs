using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Files.Excel;
using Xylia.Match.Util.ItemData;
using Xylia.Match.Util.ItemMatch.Util;
using Xylia.Preview.Common.Interface.RecordAttribute;
using Xylia.Preview.Data;
using Xylia.Preview.Data.Helper;

namespace Xylia.Match.Util.ItemList
{
	public sealed class ItemMatch
	{
		#region Constructor
		private readonly Action<string> GetOutput = null;

		public ItemMatch(Action<string> action)
		{
			Application.DoEvents();
			this.GetOutput = action;
		}
		#endregion

		#region Cache
		/// <summary>
		/// 只输出新数据
		/// </summary>
		public bool Chk_OnlyNew;

		private HashSet<int> CacheList = null;

		public void LoadCache(string Path)
		{
			if (!this.Chk_OnlyNew) return;

			this.CacheList = ChvLoad.LoadData(Path, this.GetOutput);
		}
		#endregion

		#region Data
		DateTime CreatedAt;

		List<ItemDataInfo> ItemDatas;

		BlockingCollection<ItemDataInfo> Failures;


		public bool GetData()
		{
			#region Initialize
			DataTableSet set = new();
			set.LoadData();

			CreatedAt = set.CreatedAt;


			set.Item.TryLoad();
			set.TextData.TryLoad();

			var InfoGet = new InfoGet(set);
			this.Failures = new();
			#endregion

			#region Data
			var Result = new BlockingCollection<ItemDataInfo>();
			Parallel.ForEach(set.Item, item =>
			{
				var record = ((DbData)item.Attributes).record;

				var MainID = record.RecordId;
				if (CacheList != null && CacheList.Contains(MainID)) return;

				var alias = record.StringLookup.GetString(0).Replace("SEW_", "GB_");
				var name2 = InfoGet.GetName2(alias);
				var data = new ItemDataInfo()
				{
					id = MainID,
					Alias = alias,

					Name2 = name2,
					Info = InfoGet.GetInfo(alias),
					Desc = InfoGet.GetDesc(alias),
					Job = InfoGet.GetJob(alias),
				};

				Result.Add(data);
				if (name2 is null) Failures.Add(data);
			});
			#endregion


			set = null;
			this.ItemDatas = Result.OrderBy(o => o.id).ToList();
			return this.ItemDatas.Any();
		}
		#endregion


		#region Output
		public bool UseExcel = false;

		public string Folder_Output = null;

		public FilePath File = new();



		public void Start(DateTime StartTime)
		{
			var time = CreatedAt == default ? StartTime : CreatedAt;
			var outdir = Folder_Output + $@"\信息导出\物品列表\{ time:yyyy年MM月\\dd日 HH时mm分}";
			Directory.CreateDirectory(outdir);

			File.CacheList = Path.Combine(outdir, $@"{time:yyyy-MM-dd HH-mm}.chv");
			File.Failure = Path.Combine(outdir, @"未汉化道具.txt");
			File.PlainTXT = Path.Combine(outdir, @"output." + (UseExcel ? "xlsx" : "txt"));


			ChvLoad cache = new();
			cache.DataTime = CreatedAt.GetTimeStamp();

			if (CacheList != null) cache.datas.AddRange(CacheList);
			cache.datas.AddRange(this.ItemDatas.Select(item => item.id));

			cache.Save(File.CacheList);



			#region Output
			if (UseExcel) this.CreateExcel(this.ItemDatas);
			else this.CreateText(this.ItemDatas);

			Application.DoEvents();


			if (this.Failures.Any())
			{
				using StreamWriter Out_Failure = new(File.Failure);
				foreach (var Item in this.Failures) Out_Failure.WriteLine($"{ Item.id,-20 }   { Item.Alias}");
			}
			#endregion

			#region END
			TimeSpan ts = DateTime.Now - StartTime;
			GetOutput($"本次拉取数据共计{ this.ItemDatas.Count }条, 总耗{ ts.Minutes }分{ ts.Seconds }秒。");

			this.ItemDatas.Clear();
			this.ItemDatas = null;

			this.Failures = null;
			#endregion
		}


		private void CreateExcel(IEnumerable<ItemDataInfo> Info)
		{
			#region Title
			var info = new ExcelInfo("道具数据");
			info.SetColumn("代码", 10);
			info.SetColumn("名称", 30);
			info.SetColumn("标识", 30);
			info.SetColumn("key", 10);

			info.SetColumn("专用", 20);
			info.SetColumn("描述", 80);
			info.SetColumn("信息", 80);
			#endregion

			foreach (var Item in Info)
			{
				var row = info.CreateRow();
				row.AddCell(Item.id);
				row.AddCell(Item.Name2);
				row.AddCell(Item.Alias);
				row.AddCell(Convert.ToBase64String(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Item.id))));

				row.AddCell(Item.Job);
				row.AddCell(Item.Desc);
				row.AddCell(Item.Info);
			}

			info.Save(File.PlainTXT);
		}

		private void CreateText(IEnumerable<ItemDataInfo> Info)
		{
			using var Out_Main = new StreamWriter(new FileStream(File.PlainTXT, FileMode.Create));

			foreach (var Item in Info)
			{
				string Message = null;
				string IdTxt = $"{ Item.id, -15 }";
				if (IdTxt.Length > 15) IdTxt += "    ";


				if (Item.Name2 is null) Message = $"{ IdTxt }  暂无汉化 ({ Item.Alias })";
				else
				{
					string ResultTxt = $"{ Item.Name2, -20 }";
					if (ResultTxt.Length > 15) ResultTxt += "    ";

					Message = $"{ IdTxt }{ ResultTxt }{ "别名：" + Item.Alias }";
				}

				#region info
				var ExtraInfo = new List<KeyValuePair<string, string>>()
				{
					 new KeyValuePair<string, string>("职业" ,Item.Job),
					 new KeyValuePair<string, string>("描述" ,Item.Desc),
					 new KeyValuePair<string, string>("信息" ,Item.Info),
				};

				foreach (var t in ExtraInfo.Where(t => !string.IsNullOrWhiteSpace(t.Value)))
				{
					Message += $"\t{t.Key}：{t.Value}";
				}
				#endregion

				Out_Main.WriteLine(Message.Replace("<br>", "\r\n"));
			}
		}
		#endregion
	}
}