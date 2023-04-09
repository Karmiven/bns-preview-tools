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
		#region Constructor
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

		#region Params
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

		#region Functions
		public object Handle(HtmlNode ArgNode)
		{
			#region Initialize
			string p = ArgNode.Attributes["p"]?.Value;

			if (!p.Contains(':')) return null;
			var ps = p.Split(':');
			string ArgType = ps[0], ArgValue = ps[1];

			//arg tree
			var args = ArgValue.Split('.').Select(o => new ArgItem(o)).ToArray();
			for (int x = 0; x < args.Length; x++)
			{
				if (x != 0) 
					args[x].Prev = args[x - 1];

				if (x != args.Length - 1) 
					args[x].Next = args[x + 1];
			}
			#endregion


			object ExecObj = null;
			for (int x = 0; x < args.Length; x++)
			{
				var item = args[x];
				if (x == 0)
				{
					if (ArgType == "seq")
					{
						var seq = ArgNode.Attributes["seq"]?.Value;
						var name = seq.Split(':')[0];
						var value = seq.Split(':')[1];

						ExecObj = value.CastSeq(name);
					}

					else if (ArgType == "id")
					{
						var id = ArgNode.Attributes["id"]?.Value;

						ExecObj = id.CastObject();
						item.ValidType(ref ExecObj);
					}

					else
					{
						if (!byte.TryParse(ArgType, out var index)) throw new InvalidCastException("非法参数, 应为数值类型: " + ArgType);

						ArgumentNullException.ThrowIfNull(Params);
						if (Params.Count < index) throw new ArgumentOutOfRangeException(nameof(Params));

						ExecObj = Params[index - 1];
						item.ValidType(ref ExecObj);
					}
				}
				else
				{
					var CurObj = item.GetObject(ExecObj);
					if (CurObj is null) break;
					else ExecObj = CurObj;
				}
			}

			return ExecObj;
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
					Debug.WriteLine($"handle arg failed: {html}\n\t{ex.Message}");
				}
			}

			return Text;
		}
		#endregion
	}



	public sealed class ArgItem
	{
		#region Constructor
		public ArgItem(string target) => this.Target = target;

		private readonly string Target;

		public ArgItem Prev;

		public ArgItem Next;
		#endregion


		#region Functions
		public override string ToString() => this.Target;


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

		public object GetObject(object value)
		{
			if (value is null) return null;

			if (value is string @string) return @string;
			else if (value is Bitmap @bitmap)
			{
				if (this.Target == "scale") return value;
				if (this.Prev.Target == "scale")
				{
					float Scale = 0.01F * int.Parse(this.Target);
					return new Bitmap(bitmap,
						(int)(Scale * bitmap.Width),
						(int)(Scale * bitmap.Height));
				}
			}
			else if (value is Enum @enum)
			{
				if (value is KeyCommandSeq KeyCommond) return GetObject(KeyCommond.GetKeyCommand());
				else if (value is KeyCode KeyCode) return GetObject(KeyCode.GetKeyCap());


				return $"[{ @enum.GetDescription() }]";
			}
			else if (value is IArgParam @ArgParam)
			{
				var result = ArgParam.ParamTarget(this.Target);
				if (result != null) return result;
			}
			else
			{
				var result = value.GetInfo(this.Target, true);
				if (result != null) return result.GetValue(value);
			}

			Debug.WriteLine($"NOT SUPPORTED { value } ({ value.GetType().Name } > { this.Target })");
			return null;
		}
		#endregion
	}
}