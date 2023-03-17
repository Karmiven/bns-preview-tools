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

using NPOI.SS.UserModel;

using Xylia.Configure;
using Xylia.Extension;
using Xylia.Files.Excel;

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
			this.SaveAsBin.Checked = Ini.ReadValue(this.GetType(), nameof(SaveAsBin)).ToBool();
			this.TextBox2.Text = Ini.ReadValue(this.GetType(), nameof(TextBox2));


			this.ucCheckBox1.Checked = false;

			string OutPath = Ini.ReadValue(this.GetType(), nameof(TextBox1));
			this.filePath.Text = this.Local_SourcePath;
			if (!string.IsNullOrWhiteSpace(OutPath) && File.Exists(OutPath)) TextBox1.Text = OutPath;
			else TextBox1.Text = Path.GetDirectoryName(filePath.Text) + @"\汉化数据.xlsx";
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
			Save.Filter = "txt file|*.txt|xml file|*.xml";
			if (Save.ShowDialog() != DialogResult.OK) return;

			Step1.StepIndex = 2;
			Extract(Source, Save.FileName);
			Step1.StepIndex = 3;
		}

		public static void Extract(string Source, string OutPath)
		{
			new Thread(act =>
			{
				string path = OutPath;
				string ext = Path.GetExtension(OutPath);

				var table = new LocalDataTableSet(Source).TextData;
				table.TryLoad();

				if (ext == ".xml")
				{
					table.ProcessTable(Path.GetDirectoryName(path));
				}
				else if (ext == ".xlsx")
				{
					var excel = new ExcelInfo("汉化文档");
					excel.SetColumn("alias", 50);
					excel.SetColumn("text", 100);

					ISheet CreateOutputSheet(IWorkbook workbook, string Name)
					{
						ISheet sheet = workbook.CreateSheet(Name);

						//中心
						ICellStyle CenterStyle = workbook.CreateStyle(new IStyle() { HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment.Center });

						IRow TitleRow = sheet.CreateRow(0);

						TitleRow.CreateCell(0).SetCellValue("汉化别名");
						TitleRow.CreateCell(1).SetCellValue("汉化文本");

						TitleRow.Cells[0].CellStyle = CenterStyle;
						TitleRow.Cells[1].CellStyle = CenterStyle;

						sheet.SetColumnWidth(0, 256 * 50);
						sheet.SetColumnWidth(1, 256 * 150);

						return sheet;
					}


					int Row = 0;
					foreach (var record in table)
					{
						//#region 判断是否是需要的数据
						//// 韩文校验
						//if (ucCheckBox2.Checked && !record.text.RegexMatch("[\uAC00-\uD7A3]+"))
						//	continue;
						//#endregion

						#region 换表操作
						if (Row >= 1000000)
						{
							Row = 0;
							excel.MainSheet = CreateOutputSheet(excel.Workbook, "汉化文档_" + (excel.Workbook.NumberOfSheets + 1));
						}
						#endregion

						var CurRow = excel.CreateRow(++Row);
						CurRow.AddCell(record.alias);
						CurRow.AddCell(record.text);
					}

					excel.Save(OutPath);
				}

				GC.Collect();
			}).Start();
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

					FrmTips.ShowTips(null, "操作已强制终止!");
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
													$"<span class=\"Text\" >{ HtmlSupport.ToHTML(Item.Value.text, out _) }</span>" +
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
													$"<span class=\"Text\" >{ HtmlSupport.ToHTML(Item.Value.text, out _) }</span>" +
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
					CompareThread = null;

					GC.Collect();
	
					this.Invoke(() => FrmTips.ShowTipsSuccess(null, HasChanged ? "执行已经结束,请在输出目录查看" : "执行已结束，但是未发现任何变更"));
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







		public bool Loaded = false;

		private const string OutputFilter = "受支持的文件|*.xlsx;*.xls;*.xml|表格文件|*.xlsx;*.xls|XML文件|*.xml|所有文件|*.*";

		public string Local_SourcePath { get => Ini.ReadValue(this.GetType(), "SourcePath"); set => Ini.WriteValue(this.GetType(), "SourcePath", value); }

		private void ucBtnFillet5_BtnClick(object sender, EventArgs e)
		{
			var OpenFile = new OpenFileDialog
			{
				Filter = OutputFilter,
				FileName = "汉化数据",

				CheckFileExists = true,
				CheckPathExists = false,
			};

			if (OpenFile.ShowDialog() == DialogResult.OK) TextBox2.Text = OpenFile.FileName;
			else FrmTips.ShowTipsError(null, "用户退出操作");
		}
		
		private void ucBtnFillet6_BtnClick(object sender, EventArgs e)
		{
			#region 初始化
			if (!File.Exists(filePath.Text))
			{
				FrmTips.ShowTipsError(null, "未选择local.dat文件");
				return;
			}
			else if (File.Exists(TextBox1.Text))
			{
				var result = MessageBox.Show("继续操作会覆盖数据，请更名或备份数据！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if (result != DialogResult.OK)
				{
					FrmTips.ShowTipsSuccess(null, "用户结束操作");
					return;
				}
			}
			#endregion


			Extract(filePath.Text, TextBox1.Text);
			FrmTips.ShowTipsSuccess(null, "输出已完成");
		}

		private void ucBtnFillet8_BtnClick(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new()
			{
				Filter = "汉化文件|local*.dat"
			};

			if (!string.IsNullOrWhiteSpace(filePath.Text) && Directory.Exists(filePath.Text))
			{
				fileDialog.InitialDirectory = filePath.Text;
			}

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				filePath.Text = fileDialog.FileName;
			}
		}

		private void ucBtnFillet9_BtnClick(object sender, EventArgs e)
		{
			FileDialog Dialog = ucCheckBox1.Checked ? new OpenFileDialog() : new SaveFileDialog();
			Dialog.Filter = ucCheckBox1.Checked ? "dat文件|*.dat" : OutputFilter;
			Dialog.FileName = ucCheckBox1.Checked ? "local64.dat" : "汉化数据";

			Dialog.CheckFileExists = ucCheckBox1.Checked;


			if (Dialog.ShowDialog() == DialogResult.OK) TextBox1.Text = Dialog.FileName;
			else FrmTips.ShowTipsError(null, "用户退出操作");
		}

		private void ucBtnFillet11_BtnClick(object sender, EventArgs e)
		{
			#region 初始化
			string DatPath = filePath.Text;
			bool is64 = Path.GetFileName(DatPath).Contains("64");
			string TransFile = string.IsNullOrWhiteSpace(TextBox1.Text) ? Path.GetDirectoryName(filePath.Text) + @"\汉化数据.json" : TextBox1.Text;

			string SavePath = DatPath;

			if (!File.Exists(DatPath))
			{
				Tip.Message("没有选择local(64).dat文件");
				return;
			}

			if (!File.Exists(TransFile))
			{
				Tip.Message("没有选择汉化数据文件");
				return;
			}

			if (SaveAsBin.Checked)
			{
				SavePath = Path.GetDirectoryName(DatPath) + $@"\localfile{ (is64 ? "64" : null) }.bin";
			}
			#endregion


			throw new NotImplementedException("功能异常");

			new Thread((ThreadStart)delegate
			{
				//var Entity = new BTranslate(DatPath, null);

				//try
				//{
				//	if (ucCheckBox1.Checked)
				//	{
				//		Entity.Translate_Convert(TextBox1.Text);
				//	}
				//	else
				//	{
				//		Entity.trans = new bns.Util.Data.Bin.Entity.Group.TranslateReader();

				//		Translate.TransLoad(Entity.trans, TransFile);
				//		Translate.TransLoad(Entity.trans, this.TextBox2.Text);
				//	}


				//	Entity.Translate(SavePath, !SaveAsBin.Checked);

				//	FrmTips.ShowTipsSuccess("操作完成");
				//}
				//catch (ArgumentNullException ee)
				//{
				//	Xylia.Tip.Message(ee.Message);
				//}
				//catch (Exception ee)
				//{
				//	Xylia.Tip.Message($"封包过程中发生未知错误\n\n{ ee}");
				//}
				//finally
				//{
				//	Entity?.trans.Dispose();

				//	Entity.trans = null;
				//	Entity = null;

				//	GC.Collect();
				//}


			}).Start();
		}


		private void ucCheckBox1_CheckedChangeEvent(object sender, EventArgs e)
		{
			this.Label2.Visible = this.TextBox2.Visible = ucBtnFillet5.Visible = !ucCheckBox1.Checked;


			if (ucCheckBox1.Checked)
			{
				this.ucBtnFillet3.BtnText = "替换";
				this.Label1.Text = "替换来源";
				this.TextBox1.Text = null;
			}
			else
			{
				this.ucBtnFillet3.BtnText = "封包";
				this.Label1.Text = "汉化文件";
				this.filePath_TextChanged(null, null);
			}
		}

		private void filePath_TextChanged(object sender, EventArgs e)
		{
			var path = this.Local_SourcePath = filePath.Text;

			if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
				TextBox1.Text = Path.GetDirectoryName(path) + @"\汉化数据.xlsx";
		}

		private void ucCheckBox2_CheckedChangeEvent(object sender, EventArgs e) => Ini.WriteValue(this.GetType(), ((Control)sender).Name, SaveAsBin.Checked);

		private void TextBox2_TextChanged(object sender, EventArgs e) => Ini.WriteValue(this.GetType(), ((Control)sender).Name, ((Control)sender).Text);

		private void TextBox1_TextChanged(object sender, EventArgs e) => Ini.WriteValue(this.GetType(), ((Control)sender).Name, ((Control)sender).Text);

		private void DoubleClickPath(object sender, EventArgs e)
		{
			//((Control)sender).DoubleClickPath();
		}
	}
}