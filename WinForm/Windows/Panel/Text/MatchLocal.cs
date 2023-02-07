﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

using HZH_Controls.Forms;

using Xylia.Configure;

using Xylia.Preview.Data.Helper;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Properties;

namespace Xylia.Match.Windows.Panel.TextInfo
{
	[DesignTimeVisible(false)]
	public partial class MatchLocal : UserControl
	{
		public MatchLocal()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;

			this.Path_Local1.Text = Ini.ReadValue(this.GetType(), nameof(Path_Local1));
			this.Path_Local2.Text = Ini.ReadValue(this.GetType(), nameof(Path_Local2));
		}


		#region 浏览文件
		private void Button2_Click(object sender, EventArgs e) => OpenLocal(Path_Local1);
		private void Button1_Click(object sender, EventArgs e) => OpenLocal(Path_Local2);

		private void pictureBox1_Click(object sender, EventArgs e) => (Path_Local2.Text, Path_Local1.Text) = (Path_Local1.Text, Path_Local2.Text);

		private void DataPath_TextChanged(object sender, EventArgs e)
		{
			string path = ((Control)sender).Text;
			string ext = null;

			if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
			{
				ext = Path.GetExtension(path);
				Ini.WriteValue(this.GetType(), ((Control)sender).Name, path);
			}

			//显示输出按钮
			(sender == Path_Local1 ? ucBtnFillet2 : ucBtnFillet3).Visible = ext == ".dat" || ext == ".bin";
		}

		private void OpenLocal(TextBox Text)
		{
			Open.Filter = @"汉化文件|local*.dat|外部汉化文件|TextData*.xml|所有文件|*.*";
			Open.RestoreDirectory = false;

			if (Open.ShowDialog() == DialogResult.OK)
			{
				Text.Text = Open.FileName;
			}
		}
		#endregion

		#region 输出文本
		private void Btn_OutLocal_1_Click(object sender, EventArgs e) => OutLocal(Path_Local1.Text);
		private void Btn_OutLocal_2_Click(object sender, EventArgs e) => OutLocal(Path_Local2.Text);

		public void OutLocal(string Source)
		{
			Save.FileName = "TextData";
			Save.Filter = "txt文件|*.txt|xml文件|*.xml";

			if (Save.ShowDialog() == DialogResult.OK)
			{
				new Thread(act =>
				{
					Step1.StepIndex = 2;
					string path = Save.FileName;
					string ext = Path.GetExtension(Save.FileName);


					try
					{
						if (ext == ".xml")
						{
							var table = new LocalDataTableSet(Source).TextData;
							table.TryLoad();
							table.ProcessTable(Path.GetDirectoryName(path));

							Step1.StepIndex = 4;
							return;
						}


						#region 初始化
						var Local = GetLocalInfo(Source);
						Step1.StepIndex = 3;

						if (!Local.Any())
						{
							Tip.Message("解析文件失败");
							return;
						}
						#endregion

						#region 输出内容		
						if (ext == ".html")
						{
							StreamWriter sw = path.CreateWriter();

							int i = 0, index = 1;

							foreach (var item in Local)
							{
								i++;

								if (i >= 30000)
								{
									sw.Close();
									sw.Dispose();
									sw = (path.Replace(".html", null) + $"_{ index++ }.html").CreateWriter();
									i = 0;
								}

								sw.Write(HtmlSupport.HtmlConvert($"<div class=\"Content\">" +

																			   $"<div class=\"Content_Title\">" +
																					   $"<span class=\"Sign\" >特征值：</span>" +
																					   $"<span class=\"Text\" >{ item.alias }</span>" +
																			   $"</div>" +

																			   $"<div class=\"Content_New\" >" +
																						 $"<span class=\"Sign\" >文本：</span>" +
																						 $"<span class=\"Text\" >{ HtmlSupport.ToHTML(item.text) }</span>" +
																						 $"<span class=\"Text\" >{ HtmlSupport.ToHTML(item.text) }</span>" +
																				$"</div>" +

																			   $"<div class=\"Separator\" >{  MatchLocal.Line  }</div>" +

																	$"</div>"));
							}

							sw.Close();
							sw.Dispose();
						}
						else
						{
							using StreamWriter Out_Main = new(path);
							foreach (var item in Local)
							{
								if (false)
								{
									Out_Main.WriteLine($"    <case handle=\"add\">");
									Out_Main.WriteLine($"      <word Index=\"0\">{ item.alias }</word>");
									Out_Main.WriteLine($"      <word Index=\"1\"><![CDATA[{ item.text }]]></word>");
									Out_Main.WriteLine($"    </case>");
								}
								else
								{
									Out_Main.WriteLine(item.alias);
									Out_Main.WriteLine();
									Out_Main.WriteLine(item.text);
									Out_Main.WriteLine(MatchLocal.Line);
								}
							}
						}

						Step1.StepIndex = 4;
						Local.Clear();
						Local = null;
						#endregion
					}
					catch (Exception ee)
					{
						Tip.Message(ee.Message);
					}

				}).Start();
			}
		}
		#endregion








		#region 比对不同版本的汉化
		Thread CompareThread { get; set; }

		private void Btn_End_BtnClick(object sender, EventArgs e)
		{
			if (CompareThread == null) CompareExec();
			else if (FrmDialog.ShowDialog(this, "是否确认终止操作？", blnShowCancel: true) == DialogResult.OK) CompareEnd();
		}

		/// <summary>
		/// 强制终止操作
		/// </summary>
		public void CompareEnd()
		{
			try
			{
				this.Invoke(new Action(() =>
				{
					CompareThread.Interrupt();
					CompareThread = null;

					FrmTips.ShowTips(null , "操作已强制终止!");
					ucBtnFillet1.Enabled = ucBtnFillet4.Enabled = pictureBox1.Enabled = true;
					Btn_StartWithEnd.BtnText = "开始";
				}));
			}
			catch
			{

			}
		}

		/// <summary>
		/// 匹配开始执行
		/// </summary>
		public void CompareExec()
		{
			if (!Directory.Exists(CommonPath.OutputFolder))
			{
				FrmTips.ShowTipsWarning(null, "请先设置导出文件夹路径！");
				return;
			}

			if (!File.Exists(Path_Local1.Text))
			{
				FrmTips.ShowTipsError(null, "旧版本的汉化文件不存在！");
				return;
			}

			if (!File.Exists(Path_Local2.Text))
			{
				FrmTips.ShowTipsError(null, "新版本的汉化文件不存在！");
				return;
			}

			ucBtnFillet1.Enabled = ucBtnFillet4.Enabled = pictureBox1.Enabled = false;
			Btn_StartWithEnd.BtnText = "终止";

			CompareThread = new Thread((ThreadStart)delegate
			{
				try
				{
					Step1.StepIndex++;

					string OutPath = CommonPath.OutputFolder + $@"\信息导出\汉化数据\{ DateTime.Now:yyyy年MM月\\dd日\\HH时mm分}.html";
					if (!Directory.Exists(Path.GetDirectoryName(OutPath)))
						Directory.CreateDirectory(Path.GetDirectoryName(OutPath));



					#region 初始化
					Step1.StepIndex = 2;

					var sw = OutPath.CreateWriter();

					var Sin_Old = new Dictionary<string, Text>();  //旧汉化文件
					var Sin_New = new Dictionary<string, Text>();  //新汉化文件

					foreach (var info in GetLocalInfo(Path_Local1.Text))
					{
						if (string.IsNullOrWhiteSpace(info.alias)) continue;
						Sin_Old[info.alias] = info;
					}

					foreach (var info in GetLocalInfo(Path_Local2.Text))
					{
						if (string.IsNullOrWhiteSpace(info.alias)) continue;
						Sin_New[info.alias] = info;
					}
					#endregion

					#region 进行比对
					Step1.StepIndex = 3;

					bool HasChanged = false;
					foreach (var Item in Sin_New)
					{
						//如果旧汉化中没有，判断为新增
						if (!Sin_Old.ContainsKey(Item.Key))
						{
							HasChanged = true;

							sw.Write(HtmlSupport.HtmlConvert($"<div class=\"Content\">" +
													$"<div class=\"Content_Title\">" +
													$"<span class=\"Sign\" >[新增] 特征值：</span>" +
													$"<span class=\"Text\" >{ Item.Value.alias }</span>" +
												 $"</div>" +
												 $"<div class=\"Content_New\" >" +
													$"<span class=\"Sign\" >文本：</span>" +
													$"<span class=\"Text\" >{ HtmlSupport.ToHTML(Item.Value.text) }</span>" +
												 $"</div>" +

												 $"<div class=\"Separator\" >{  MatchLocal.Line  }</div>" +
												 $"</div>"));


							//Debug.WriteLine(Item.Value.alias + "$" + Item.Value.Text);
						}


						//如果旧汉化中有，但是不相同
						else
						{
							if (Sin_Old[Item.Key].text == Item.Value.text) continue;

							HasChanged = true;

							string Txt1 = HtmlSupport.ToHTML(Sin_Old[Item.Key].text, out bool IsMultiLine1);
							string Txt2 = HtmlSupport.ToHTML(Item.Value.text, out bool IsMultiLine2);


							sw.Write(HtmlSupport.HtmlConvert($"<div class=\"Content\">" +
													$"<div class=\"Content_Title\">" +
													$"<span class=\"Sign\" >[修改] 特征值：</span>" +
													$"<span class=\"Text\" >{ Item.Key }</span>" +
												$"</div>" +

												$"<div class=\"Content_Old\" >" +
													$"<span class=\"Sign\" >旧版本：</span>" +
													$"<span class=\"Text\" >{ Txt1 }</span>" +
												$"</div>" +

												//当文本信息大于单行时进行换行显示
												(IsMultiLine1 || IsMultiLine2 ? "<br/>" : null) +

												$"<div class=\"Content_New\">" +
													$"<span class=\"Sign\" >新版本：</span>" +
													$"<span class=\"Text\" >{ Txt2 }</span>" +
												$"</div>" +

												$"<div class=\"Separator\" >{ MatchLocal.Line }</div>" +

												$"</div>"));
						}
					}

					//遍历旧汉化文件并与新文件比对值
					foreach (var Item in Sin_Old)
					{
						if (!Sin_New.ContainsKey(Item.Key))
						{
							HasChanged = true;

							sw.Write(HtmlSupport.HtmlConvert($"<div class=\"Content\">" +
													$"<div class=\"Content_Title\">" +
													$"<span class=\"Sign\" >[删除] 特征值：</span>" +
													$"<span class=\"Text\" >{ Item.Key }</span>" +
												 $"</div>" +

												 $"<div class=\"Content_Old\" >" +
													$"<span class=\"Sign\" >文本：</span>" +
													$"<span class=\"Text\" >{ HtmlSupport.ToHTML(Item.Value.text) }</span>" +
												 $"</div>" +

												 $"<div class=\"Separator\" >{  MatchLocal.Line  }</div>" +
												 $"</div>"));
						}
					}
					#endregion

					#region 最后处理
					Step1.StepIndex = 4;
					Sin_Old.Clear();
					Sin_New.Clear();


					sw.Flush();
					sw.Close();
					sw.Dispose();
					GC.Collect();
					#endregion



					ucBtnFillet1.Enabled = ucBtnFillet4.Enabled = pictureBox1.Enabled = true;
					Btn_StartWithEnd.BtnText = "开始";
					GC.Collect();

					this.Invoke(new Action(() =>
					{
						FrmTips.ShowTipsSuccess(null, HasChanged ? "执行已经结束,请在输出目录查看" : "执行已结束，但是未发现任何变更");

						CompareThread = null;
						GC.Collect();
					}));
				}
				catch (Exception ee)
				{
					if (CompareThread != null && CompareThread.IsAlive) Xylia.Tip.Message(ee.ToString());
					CompareEnd();
				}
			});

			CompareThread.SetApartmentState(ApartmentState.STA);
			CompareThread.Start();
		}



		public static string Line => "﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊";

		/// <summary>
		/// 获取汉化数据
		/// </summary>
		/// <param name="FilePath"></param>
		/// <returns></returns>
		public static List<Text> GetLocalInfo(string FilePath)
		{
			if (Path.GetExtension(FilePath) == ".xml")
			{
				XmlDocument XmlDoc = new();
				XmlDoc.Load(FilePath);

				return (from XmlNode reccord in XmlDoc.SelectNodes("table/record")
						let Alias = reccord.Attributes["alias"]?.Value
						let Text = reccord.Attributes["text"]?.Value ?? reccord.InnerText
						select new Text() { alias = Alias, text = Text })
						.ToList();
			}

			else return new LocalDataTableSet(FilePath).TextData.ToList();
		}
		#endregion
	}
}