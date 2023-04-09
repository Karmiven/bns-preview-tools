using Xylia.Extension;
using Xylia.Files.Excel;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Output
{
	public sealed class WorldAccountMuseum : OutBase
	{
		protected override string Name => "万象录";

		protected override void CreateData()
		{
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

			foreach (var record in FileCache.Data.WorldAccountMuseum)
			{
				var row = this.ExcelInfo.CreateRow();
				row.AddCell(record.alias);
				row.AddCell(record.CollectionName.GetText());
				row.AddCell(record.CollectionCategory);
				row.AddCell(record.Ability1.GetName(record.AbilityValue1));
				row.AddCell(record.Ability2.GetName(record.AbilityValue2));
				row.AddCell(record.Ability3.GetName(record.AbilityValue3));


				for (int i = 1; i <= 8; i++)
				{
					var card = FileCache.Data.WorldAccountCard[record.Attributes["collection-card-" + i]];
					var count = record.Attributes["collection-card-count-" + i].ToShort();

					if (card is null) row.AddCell("");
					else row.AddCell(card.GetName() + GetCount(count));
				}
			}
		}
	}
}