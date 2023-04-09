﻿using System;
using System.IO;
using System.Windows.Forms;

using HZH_Controls.Forms;

using Xylia.Configure;
using Xylia.Files.Excel;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls;

namespace Xylia.Preview.Output
{
	public abstract class OutBase
	{
		#region Fields
		protected virtual string Name => this.GetType().Name;


		protected readonly ExcelInfo ExcelInfo = null;
		#endregion

		#region Functions
		public OutBase()
		{
			#region	Initialize
			var Save = new SaveFileDialog
			{
				Filter = "表格文件|*.xlsx",
				FileName = $"{Name} ({ DateTime.Now:yy年MM月}).xlsx",

				InitialDirectory = Ini.ReadValue("Folder", "OutputExcel")
			};
			if (Save.ShowDialog() != DialogResult.OK) return;

			Ini.WriteValue("Folder", "OutputExcel", Path.GetDirectoryName(Save.FileName));
			FrmTips.ShowTipsSuccess(null, "开始执行, 请等待结束提示");
			DateTime dt = DateTime.Now;
			#endregion

			#region 核心Functions
			this.ExcelInfo = new ExcelInfo(Name);
			this.CreateData();
			this.ExcelInfo.Save(Save.FileName);


			FrmTips.ShowTipsWarning(null, $"执行已完成, 耗时{(int)(DateTime.Now - dt).TotalSeconds}s");

			this.ExcelInfo.Dispose();
			this.ExcelInfo = null;

			GC.Collect();
			#endregion
		}

		protected virtual void CreateData()
		{

		}
		#endregion


		#region Functions
		public static string GetCount(int count) => " " + new ContentParams(count).Handle("<arg p=\"1:integer\"/>个");
		#endregion
	}

	public sealed class Custom : OutBase
	{
		protected override void CreateData()
		{
			#region Config


			
			#endregion


			#region Title
			this.ExcelInfo.SetColumn("别名", 30);
			this.ExcelInfo.SetColumn("", 25);
			this.ExcelInfo.SetColumn("", 10);

			this.ExcelInfo.SetColumn("", 15);
			this.ExcelInfo.SetColumn("", 15);
			this.ExcelInfo.SetColumn("", 15);

			this.ExcelInfo.SetColumn("", 30);
			this.ExcelInfo.SetColumn("", 30);
			this.ExcelInfo.SetColumn("", 30);
			this.ExcelInfo.SetColumn("", 30);
			this.ExcelInfo.SetColumn("", 30);
			this.ExcelInfo.SetColumn("", 30);
			this.ExcelInfo.SetColumn("", 30);
			this.ExcelInfo.SetColumn("", 30);
			#endregion

			foreach (var record in FileCache.Data.Collecting)
			{
				var row = this.ExcelInfo.CreateRow();
				row.AddCell(record.alias);
				row.AddCell(record.Name.GetText());
			}
		}
	}
}