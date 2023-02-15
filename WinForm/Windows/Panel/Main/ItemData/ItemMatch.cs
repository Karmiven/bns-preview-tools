using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using NPOI.SS.UserModel;

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
		#region 构造
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
			#region 初始化
			DataTableSet set = new();
			set.LoadData();

			CreatedAt = set.CreatedAt;


			set.Item.TryLoad();
			set.TextData.TryLoad();

			var InfoGet = new InfoGet(set);
			this.Failures = new();
			#endregion

			#region 处理数据
			var Result = new BlockingCollection<ItemDataInfo>();
			Parallel.ForEach(set.Item, item =>
			{
				//使用原始属性
				var record = ((DbData)item.Attributes).record;


				//读取数据编号
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
			File.PlainTXT = Path.Combine(outdir, @"导出数据." + (UseExcel ? "xlsx" : "txt"));


			ChvLoad cache = new();
			cache.DataTime = CreatedAt.GetTimeStamp();

			if (CacheList != null) cache.datas.AddRange(CacheList);
			cache.datas.AddRange(this.ItemDatas.Select(item => item.id));

			cache.Save(File.CacheList);



			#region 输出信息
			if (UseExcel) this.CreateExcel(this.ItemDatas);
			else this.CreateText(this.ItemDatas);   //以普通文本形式生成

			//异常信息
			if (this.Failures.Any())
			{
				using StreamWriter Out_Failure = new(File.Failure);
				foreach (var Item in this.Failures) Out_Failure.WriteLine($"{ Item.id,-20 }   { Item.Alias}");
			}
			#endregion

			#region 最后处理
			TimeSpan ts = DateTime.Now - StartTime;
			GetOutput($"本次拉取数据共计{ this.ItemDatas.Count }条，总耗{ ts.Minutes }分{ ts.Seconds }秒。");

			this.ItemDatas.Clear();
			this.ItemDatas = null;

			this.Failures = null;
			#endregion
		}

		/// <summary>
		/// 生成表格格式文件
		/// </summary>
		public void CreateExcel(IEnumerable<ItemDataInfo> Info)
		{
			IWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
			ISheet sheet = workbook.CreateSheet("道具数据");
			ICellStyle style = workbook.CreateStyle();

			try
			{
				#region 标题
				IRow TitleRow = sheet.CreateRow(0);
				TitleRow.CreateCell(0).SetCellValue("物品代码");
				TitleRow.CreateCell(1).SetCellValue("物品名称");
				TitleRow.CreateCell(2).SetCellValue("物品标识");
				TitleRow.CreateCell(3).SetCellValue("专用职业");
				TitleRow.CreateCell(4).SetCellValue("物品描述");
				TitleRow.CreateCell(5).SetCellValue("物品信息");

				//设置单元格字体
				for (int i = 0; i <= 5; i++) TitleRow.GetCell(i).CellStyle = style;

				sheet.SetColumnWidth(0, 256 * 10);
				sheet.SetColumnWidth(1, 256 * 30);
				sheet.SetColumnWidth(2, 256 * 30);
				sheet.SetColumnWidth(3, 256 * 20);
				sheet.SetColumnWidth(4, 256 * 80);
				sheet.SetColumnWidth(5, 256 * 80);
				#endregion

				int Row = 1;
				foreach (var Item in Info)
				{
					IRow rowData = sheet.CreateRow(Row++);

					rowData.CreateCell(0).SetCellValue(Item.id);
					rowData.CreateCell(1).SetCellValue(Item.Name2);
					rowData.CreateCell(2).SetCellValue(Item.Alias);
					rowData.CreateCell(3).SetCellValue(Item.Job);
					rowData.CreateCell(4).SetCellValue(Item.Desc);
					rowData.CreateCell(5).SetCellValue(Item.Info);

					for (int i = 0; i <= 5; i++) rowData.GetCell(i).CellStyle = style;
				}

				Application.DoEvents();

				//保存为Excel文件
				workbook.Save(File.PlainTXT);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// 生成文本格式文件
		/// </summary>
		/// <param name="Info"></param>
		public void CreateText(IEnumerable<ItemDataInfo> Info)
		{
			using var Out_Main = new StreamWriter(new FileStream(File.PlainTXT, FileMode.Create));

			foreach (var Item in Info)
			{
				string Message = null;
				string IdTxt = $"{ Item.id,-15 }";
				if (IdTxt.Length > 15) IdTxt += "    ";


				if (Item.Name2 is null) Message = $"{ IdTxt }  暂无汉化 ({ Item.Alias })";
				else
				{
					string ResultTxt = $"{ Item.Name2,-20 }";
					if (ResultTxt.Length > 15) ResultTxt += "    ";

					Message = $"{ IdTxt }{ ResultTxt }{ "别名：" + Item.Alias }";
				}

				#region 获取道具的标识和文本
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