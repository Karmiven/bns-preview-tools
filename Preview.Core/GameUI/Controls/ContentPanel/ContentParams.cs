using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

using HtmlAgilityPack;

using Xylia.Extension;
using Xylia.Preview.Common.Arg;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.GameUI.Controls
{
	public sealed class ContentParams
	{
		#region 构造
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		readonly List<object> Params = new();

		public ContentParams()
		{
			Params.Add(new Creature() { Job = FileCache.Data.Job.FirstOrDefault(o => o.job == JobSeq.검사) });
		}

		public ContentParams(params object[] args)
		{
			Params.AddRange(args);
		}
		#endregion


		#region 参数组
		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="ArgIndex">The zero-based index of the element to get or set.</param>
		/// <returns></returns>
		public object this[int ArgIndex]
		{
			get => this.Params[ArgIndex - 1];
			set
			{
				if (ArgIndex > Params.Count)
				{
					int count = ArgIndex - Params.Count;
					for (int x = 0; x < count; x++)
						Params.Add(null);
				}

				this.Params[ArgIndex - 1] = value;
			}
		}

		/// <summary>
		///  Adds an object to the end of the <see cref="Params"/>.
		/// </summary>
		/// <param name="item"></param>
		public void Add(object item) => this.Params.Add(item);

		public void Clear() => this.Params.Clear();
		#endregion

		#region 处理数据
		public object Handle(HtmlNode ArgNode)
		{
			#region 初始化
			//获取参数
			string p = ArgNode.Attributes["p"]?.Value;

			if (!p.Contains(':')) return null;
			var ps = p.Split(':');
			string ArgType = ps[0], ArgValue = ps[1];

			//创建目标树
			var args = new List<ArgItem>();
			foreach (var node in ArgValue.Split('.'))
				args.Add(new ArgItem(node, args.LastOrDefault()));
			#endregion

			#region 逐级处理
			object ExecObj = null;
			for (int x = 0; x < args.Count; x++)
			{
				var item = args[x];
				if (x == 0)
				{
					//枚举
					if (ArgType == "seq")
					{
						var seq = ArgNode.Attributes["seq"]?.Value;
						var name = seq.Split(':')[0];
						var value = seq.Split(':')[1];

						ExecObj = value.CastSeq(name);
					}

					//特定对象
					else if (ArgType == "id")
					{
						var id = ArgNode.Attributes["id"]?.Value;

						ExecObj = id.CastObject();
						item.ValidType(ref ExecObj);
					}

					//动态对象
					else
					{
						if (!byte.TryParse(ArgType, out var index)) throw new InvalidCastException("非法参数，应为数值类型: " + ArgType);

						ArgumentNullException.ThrowIfNull(Params);
						if (Params.Count < index) throw new ArgumentOutOfRangeException(nameof(Params));

						ExecObj = Params[index - 1];
						item.ValidType(ref ExecObj);
					}
				}
				else
				{
					//获取当前层级对象信息
					var CurObj = item.GetObject(ExecObj);
					if (CurObj is null) break;
					else ExecObj = CurObj;
				}
			}

			return ExecObj;
			#endregion
		}

		public string Handle(string Text)
		{
			foreach (Match m in new Regex("<arg.*?/>").Matches(Text))
			{
				string html = m.ToString();
				var doc2 = new HtmlDocument();
				doc2.LoadHtml(html);

				try
				{
					var result = Handle(doc2.DocumentNode.FirstChild);
					var text = result is int @int ? @int.ToString("N0") : result?.ToString();

					Text = Text.Replace(html, text);
				}
				catch (Exception ex)
				{
					Debug.WriteLine($"处理失败: {html}\n\t{ex.Message}");
				}
			}

			return Text;
		}
		#endregion
	}



	public sealed class ArgItem
	{
		#region 构造
		public ArgItem(string target, ArgItem parent = null)
		{
			this.Target = target;
			this.Parent = parent;
		}


		private readonly string Target;

		private readonly ArgItem Parent;
		#endregion

		#region 方法
		/// <summary>
		/// 验证对象
		/// </summary>
		/// <param name="value"></param>
		/// <exception cref="InvalidCastException"></exception>
		public void ValidType(ref object value)
		{
			if (value is null) return;

			var type = value.GetType();
			if (Target == "string")
			{
				if (type != typeof(string)) value = value.ToString();
				return;
			}
			else if (Target == "integer")
			{
				if (type == typeof(int))
				{
					value = new Integer((int)value);
					return;
				}

				else if (type == typeof(short))
				{
					value = new Integer((short)value);
					return;
				}

				else if (type == typeof(byte))
				{
					value = new Integer((byte)value);
					return;
				}

				else if (type == typeof(float))
				{
					value = new Integer((float)value);
					return;
				}
			}

			//实例类型
			else if (Target == "skill" && value is Skill3) return;
			else if (Target.MyEquals(value.GetType().Name)) return;

			throw new InvalidCastException($"Valid Failed: {Target} > {value.GetType()}");
		}

		/// <summary>
		/// 获得对象
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public object GetObject(object value)
		{
			if (value is null) return null;


			// 文本数据
			if (value is string @string) return @string;
			// 图片数据
			if (value is Bitmap @bitmap)
			{
				//图片缩放到比例
				if (this.Target == "scale") return value;
				if (this.Parent.Target == "scale")
				{
					return value;

					int Scale = int.Parse(this.Target);
					return new Bitmap(bitmap, Scale, Scale);
				}
			}
			// 枚举数据
			else if (value is Enum @enum)
			{
				if (value is KeyCommandSeq KeyCommond) return GetObject(KeyCommond.GetKeyCommand());
				else if (value is KeyCode KeyCode) return GetObject(KeyCode.GetKeyCap());


				return $"[{ @enum.GetDescription() }]";
			}
			// 接口数据
			else if (value is IArgParam @ArgParam)
			{
				var result = ArgParam.ParamTarget(this.Target);
				if (result != null) return result;
			}
			// 实例数据
			else
			{
				var result = value.GetInfo(this.Target, true);
				if (result != null) return result.GetValue(value);
			}


			Debug.WriteLine($"未支持 { value } ({ value.GetType().Name } > { this.Target })");
			return null;
		}
		#endregion
	}
}