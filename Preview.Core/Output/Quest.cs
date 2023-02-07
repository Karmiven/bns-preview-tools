using System.Linq;

using Xylia.Files.Excel;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Output
{
	public sealed class Quest : OutBase
	{
		protected override string Name => "任务";

		protected override void CreateData()
		{
			#region Title
			this.ExcelInfo.SetColumn("任务序号" , 10);
			this.ExcelInfo.SetColumn("任务别名" , 15);
			this.ExcelInfo.SetColumn("任务名称" , 30);
			this.ExcelInfo.SetColumn("group" , 25);
			this.ExcelInfo.SetColumn("category", 10);
			this.ExcelInfo.SetColumn("content-type", 10);
			this.ExcelInfo.SetColumn("reset-type", 10);
			this.ExcelInfo.SetColumn("retired", 10);
			this.ExcelInfo.SetColumn("tutorial", 10);
			this.ExcelInfo.SetColumn("相关副本", 35);
			#endregion

			foreach (var Quest in FileCache.Data.Quest.OrderBy(o => o.id))
			{
				var row = this.ExcelInfo.CreateRow();
				row.AddCell(Quest.id);
				row.AddCell(Quest.alias);
				row.AddCell(Quest.Name2.GetText());
				row.AddCell(Quest.Group2.GetText());
				row.AddCell(Quest.Category);
				row.AddCell(Quest.ContentType);
				row.AddCell(Quest.ResetType);
				row.AddCell(Quest.Retired);
				row.AddCell(Quest.Tutorial);
				row.AddCell(Quest.AttractionInfo.GetName());
			}
		}
	}
}