using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using HtmlAgilityPack;

using Xylia.Attribute;
using Xylia.Extension;

namespace Xylia.Match.Windows.Panel.TextInfo
{
	/// <summary>
	/// 创建css信息
	/// </summary>
	public static class HtmlSupport
	{
		/// <summary>
		/// 创建字体风格css
		/// </summary>
		/// <param name="sw"></param>
		public static void CreatCss(this StreamWriter sw)
		{
			sw.WriteLine($"<style>" +
								   //设置标题颜色
								   ".Content_Title .Sign {\n" +
								   "    color:#33FF66;\n" +
								   "    font-size:;\n" +
								   "}\n" +

								   //设置标题文本颜色
								   ".Content_Title .Text {\n" +
								   "    color:#33FF66;\n" +
								   "    font-size: ;\n" +
								   "}\n" +

								   //设置旧版本颜色
								   ".Content_Old .Sign {\n" +
								   "    color:#FF0066;\n" +
								   "    font-size: ;\n" +
								   "}\n" +

								   //设置新版本颜色
								   ".Content_New .Sign {\n" +
								   "    color:#FF0066;\n" +
								   "    font-size: ;\n" +
								   "}\n" +


									FontCreat() +


								   //为突出Font，未设置时显示为灰色
								   ".Text {\n" +
								   "    color:#C3916A;\n" +
								   "    font-size: ;\n" +
								   "}\n" +

								   "span {\n" +
								   "    color:#D3D3D3;\n" +
								   "}\n" +

								   "body {\n" +
								   "    padding: 0 0 0 50;\n" +
								   "    background: #161615;\n" +
								   "}\n" +


								   ".Separator {\n" +
								   "    color:#8CF0FE\n" +
								   "}\n" +

			$"</style>");
		}

		public static StreamWriter CreateWriter(this string outPath)
		{
			StreamWriter sw = File.AppendText(outPath);
			sw.CreatCss();

			return sw;
		}



		/// <summary>
		/// 创建字体
		/// </summary>
		/// <returns></returns>
		public static string FontCreat()
		{
			string result = null;
			//foreach (var Font in Xylia.Drawing.Font.Util.Fonts)
			//{
			//	// 默认字体大小是游戏内字体的1.5倍
			//	result += "." + Font.Name?.Replace(".", "_") + " {\n" +

			//		   "    color:" + ColorTranslator.ToHtml(Font.Color) + ";\n" +

			//		    //保留一位小数
			//			(Font.Size == null ? null : "\n\tfont-size: " + (Math.Ceiling((float)Font.Size * 10) * 0.1f).ToString("0.0") + ";") +

			//		   "\n}\n";
			//}

			return result;
		}








		/// <summary>
		/// Html处理
		/// </summary>
		/// <param name="Text"></param>
		/// <returns></returns>
		public static string HtmlConvert(this string Text) => Text.Replace("\n", "<br/>\n");

		/// <summary>
		/// 游戏专用Xml信息转换为Html信息
		/// </summary>
		/// <param name="Text"></param>
		/// <returns></returns>
		public static string ToHTML(this string Text) => ToHTML(Text, out _);

		public static string ToHTML(this string Text, out bool IsMultiLine)
		{
			IsMultiLine = false;
			if (string.IsNullOrWhiteSpace(Text)) return null;

			try
			{

				HtmlAgilityPack.HtmlDocument doc = new();
				doc.LoadHtml(Text);


				string Result = null;
				foreach (var Node in doc.DocumentNode.ChildNodes.ToList().Where(Node => !string.IsNullOrWhiteSpace(Node.Name)))
				{
					Result += HandleProperty(Node);
				}

				IsMultiLine = Regex.IsMatch(Result, @"<\s*" + "br" + @"\s*/" + @"\s*>", RegexOptions.IgnoreCase);
				return (IsMultiLine ? "\n" : null) + Result;
			}
			catch (Exception ee)
			{
				Debug.WriteLine("[ToHTML]" + ee.Message);
				return Text;
			}
		}

		public static string HandleProperty(this HtmlNode Node)
		{
			switch (Node.Name)
			{
				case "#text": return Node.InnerText;

				case "p":
				{
					return $@"<p style='text-align:{  Node.Attributes["horizontalalignment"]?.Value }; '>";
				}

				case "arg":
				{
					#region 初始化
					var p = Node.Attributes["p"]?.Value;
					var id = Node.Attributes["id"]?.Value;
					var link = Node.Attributes["link"]?.Value;

					string Content = null;
					#endregion

					#region 处理
					if (!string.IsNullOrWhiteSpace(p) && p.MyContains("id"))
					{
						var Temp = id.Split(':');
						Content = p.Replace("id:", null) + "." + Temp[1] ?? Temp[0];
					}

					return $@"<span>{ Content }</span>";
					#endregion
				}

				case "image":
				{
					#region	初始化
					var EnablesScale = Node.Attributes["enablescale"]?.Value.ToBool() ?? false;
					var Imagesetpath = Node.Attributes["imagesetpath"]?.Value;
					var Path = Node.Attributes["path"]?.Value;

					float.TryParse(Node.Attributes["scalerate"]?.Value, out float result);
					#endregion

					#region 处理
					if (EnablesScale)
					{
						//width={ img.ScaleRate *100  }% height={ img.ScaleRate * 100 }%
					}

					string IMG_Path = Imagesetpath ?? Path;
					string[] Temp = IMG_Path.Split('.');

					if (Temp.Length >= 2)
					{
						string FileName = Temp[0] + @"\" + Temp[1] + ".png";

						return $@"<img src='file://{  Xylia.Configure.PathDefine.MainFolder }Resources\Package\{ FileName }'>";
					}
					#endregion
				}
				break;

				case "font":
				{
					//获得字体名称
					string FontName = Node.Attributes["name"]?.Value;

					//仅读取颜色信息
					if (!string.IsNullOrWhiteSpace(FontName))
					{
						//去除掉包名
						if (FontName.Contains('.')) FontName = FontName.Replace(FontName.Split('.')[0] + ".", null);
					}

					return $"<span class=\"{ FontName?.Replace(".", "_") }\">{  Node.InnerText }</span>";
				}
			}

			return Node.OuterHtml;
		}
	}
}