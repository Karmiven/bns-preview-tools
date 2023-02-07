using Xylia.Files.Excel;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Output
{
	public sealed class QuestEpic : OutBase
	{
		protected override string Name => "主线任务";

		protected override void CreateData()
		{
			#region Title
			this.ExcelInfo.SetColumn("任务序号", 10);
			this.ExcelInfo.SetColumn("任务别名", 15);
			this.ExcelInfo.SetColumn("任务名称", 30);
			this.ExcelInfo.SetColumn("group", 25);
			#endregion

			QuestExtension.GetEpicInfo(data =>
			{
				var row = this.ExcelInfo.CreateRow();
				row.AddCell(data.id);
				row.AddCell(data.alias);
				row.AddCell(data.Name2.GetText());
				row.AddCell(data.Group2.GetText());
			});
		}
	}
}