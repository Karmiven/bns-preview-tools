using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using HZH_Controls.Forms;

using NPOI.SS.UserModel;

using Xylia.Configure;
using Xylia.Extension;
using Xylia.Files.Excel;
using Xylia.Preview.Data.Helper;

namespace Xylia.Match.Windows.Panel.TextInfo
{
	[DesignTimeVisible(false)]
	public partial class ModifyLocal : UserControl
	{
		#region 构造
		public ModifyLocal()
		{
			InitializeComponent();

			this.SaveAsBin.Checked = Ini.ReadValue(this.GetType(), nameof(SaveAsBin)).ToBool();
			this.TextBox2.Text = Ini.ReadValue(this.GetType(), nameof(TextBox2));
		}
		#endregion

		#region 字段
		public bool Loaded = false;

		/// <summary>
		/// 输出类型筛选
		/// </summary>
		private const string OutputFilter = "受支持的文件|*.xlsx;*.xls;*.xml|表格文件|*.xlsx;*.xls|XML文件|*.xml|所有文件|*.*";
		#endregion


		#region 控件方法
		public string Local_SourcePath { get => Ini.ReadValue(this, GetType(), "SourcePath"); set => Ini.WriteValue(this, GetType(), "SourcePath", value); }

		private void ModifyLocal_Load(object sender, EventArgs e)
		{
			this.ucCheckBox1.Checked = false;
			filePath.Text = this.Local_SourcePath;

			//获取输出路径
			string OutPath = Ini.ReadValue(this.GetType(), nameof(TextBox1));
			if (!string.IsNullOrWhiteSpace(OutPath) && File.Exists(OutPath)) TextBox1.Text = OutPath;
			else TextBox1.Text = Path.GetDirectoryName(filePath.Text) + @"\汉化数据.xlsx";

			Loaded = true;
		}

		private void ucBtnFillet1_BtnClick(object sender, EventArgs e)
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

		private void ucBtnFillet2_BtnClick(object sender, EventArgs e)
		{
			#region 初始化
			if (!File.Exists(filePath.Text))
			{
				FrmTips.ShowTipsError(null, "未选择local.dat文件");
				return;
			}
			else if (File.Exists(TextBox1.Text))
			{
				var result = MessageBox.Show("继续操作会覆盖数据，请更名或备份数据！如已完成，请点击确认。", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if (result != DialogResult.OK)
				{
					FrmTips.ShowTipsSuccess(null, "用户结束操作");
					return;
				}
			}
			#endregion


			new Thread(act =>
			{
				#region 初始化
				bool isDefault = string.IsNullOrWhiteSpace(TextBox1.Text);
				string Ext = Path.GetExtension(TextBox1.Text)?.ToLower();

				if (isDefault || Ext == ".json")
					throw new Exception("暂不支持的格式");

				var table = new LocalDataTableSet(filePath.Text).TextData;
				#endregion


				#region 根据选择格式输出内容
				if (Ext == ".xlsx" || Ext == ".xls")
				{
					#region 初始化
					var excel = new ExcelInfo("汉化文档");
					var titleRow = excel.CreateRow(0);
					titleRow.AddCell("汉化编号");
					titleRow.AddCell("汉化别名");
					titleRow.AddCell("汉化文本");
					#endregion

					#region 写入内容
					int Row = 0;
					foreach (var record in table)
					{
						#region 判断是否是需要的数据
						// 韩文校验
						if (ucCheckBox2.Checked && !record.text.RegexMatch("[\uAC00-\uD7A3]+"))
							continue;
						#endregion

						#region 换表操作
						if (Row >= 1000000)
						{
							Row = 0;
							excel.MainSheet = CreateOutputSheet(excel.Workbook, "汉化文档_" + (excel.Workbook.NumberOfSheets + 1));
						}
						#endregion


						#region 创建行基本信息
						var CurRow = excel.CreateRow(++Row);
						CurRow.AddCell(record.TableIndex);
						CurRow.AddCell(record.alias);
						CurRow.AddCell(record.text);
						#endregion
					}

					//存储
					excel.Save(TextBox1.Text);
					#endregion
				}
				else if (Ext == ".xml")
				{
					var outfile = new StreamWriter(isDefault ? Path.GetDirectoryName(filePath.Text) + @"\汉化.xml" : TextBox1.Text);
					outfile.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
					outfile.WriteLine("<table version=\"0.6\">");

					foreach (var record in table)
					{
						outfile.WriteLine($"\t<record alias=\"{ record.alias }\" >");
						outfile.WriteLine($"\t\t<![CDATA[{ record.text }]]>");
						outfile.WriteLine($"\t</record>");
					}

					outfile.WriteLine("</table>");
					outfile.Close();
				}
				#endregion

				GC.Collect();
				FrmTips.ShowTipsSuccess(null, "输出已完成");

			}).Start();
		}

		private void ucBtnFillet3_BtnClick(object sender, EventArgs e)
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

		private void ucBtnFillet4_BtnClick(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new()
			{
				Filter = "汉化文件|local*.dat"
			};

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				TextBox1.Text = fileDialog.FileName;

				//Xylia.Configure.Ini.WriteValue("Modify", "BnsFolder");
			}
		}

		private void ucCheckBox1_CheckedChangeEvent(object sender, EventArgs e)
		{
			if (ucCheckBox1.Checked)
			{
				this.ucBtnFillet3.BtnText = "替换";
				this.Label1.Text = "替换来源";

				this.TextBox1.Text = null;
				this.Label2.Visible = this.TextBox2.Visible = ucBtnFillet5.Visible = false;
			}
			else
			{
				this.ucBtnFillet3.BtnText = "封包";
				this.filePath_TextChanged(null, null);

				this.Label1.Text = "汉化文件";
				this.Label2.Visible = this.TextBox2.Visible = ucBtnFillet5.Visible = true;
			}
		}

		private void ucBtnFillet6_BtnClick(object sender, EventArgs e)
		{
			FileDialog Dialog = ucCheckBox1.Checked ? new OpenFileDialog() : new SaveFileDialog();
			Dialog.Filter = ucCheckBox1.Checked ? "dat文件|*.dat" : OutputFilter;
			Dialog.FileName = ucCheckBox1.Checked ? "local64.dat" : "汉化数据";

			Dialog.CheckFileExists = ucCheckBox1.Checked;


			if (Dialog.ShowDialog() == DialogResult.OK) TextBox1.Text = Dialog.FileName;
			else FrmTips.ShowTipsError(null, "用户退出操作");
		}

		private void filePath_TextChanged(object sender, EventArgs e)
		{
			string DatPath = filePath.Text;
			this.Local_SourcePath = DatPath;

			if (!string.IsNullOrWhiteSpace(DatPath) && File.Exists(DatPath) && Loaded)
				TextBox1.Text = Path.GetDirectoryName(DatPath) + @"\汉化数据.xlsx";
		}

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



		private void ucCheckBox2_CheckedChangeEvent(object sender, EventArgs e) => Ini.WriteValue(this.GetType(), ((Control)sender).Name, SaveAsBin.Checked);

		private void TextBox2_TextChanged(object sender, EventArgs e) => Ini.WriteValue(this.GetType(), ((Control)sender).Name, ((Control)sender).Text);

		private void TextBox1_TextChanged(object sender, EventArgs e) => Ini.WriteValue(this.GetType(), ((Control)sender).Name, ((Control)sender).Text);

		private void DoubleClickPath(object sender, EventArgs e)
		{
			//((Control)sender).DoubleClickPath();
		}
		#endregion

		#region 处理方法
		private static ISheet CreateOutputSheet(IWorkbook workbook, string Name)
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
		#endregion
	}
}