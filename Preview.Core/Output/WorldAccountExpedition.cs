using Xylia.Extension;
using Xylia.Files.Excel;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Output
{
	public sealed class WorldAccountExpedition : OutBase
	{
		protected override string Name => "探险日志";

		protected override void CreateData()
		{																							  
			#region Title
			this.ExcelInfo.SetColumn("编号", 10);
			this.ExcelInfo.SetColumn("阶段", 10);
			this.ExcelInfo.SetColumn("别名", 45);
			this.ExcelInfo.SetColumn("目录", 10);
			this.ExcelInfo.SetColumn("名称", 35);
			this.ExcelInfo.SetColumn("描述", 40);
			#endregion

			foreach (var record in FileCache.Data.WorldAccountExpedition)
			{
				var row = this.ExcelInfo.CreateRow();
				row.AddCell(record.Key());
				row.AddCell(record.Step);
				row.AddCell(record.alias);
				row.AddCell(record.Category);
				row.AddCell(record.Name.GetText());
				row.AddCell(record.Description.GetText());
				row.AddCell(record.Tooltip1.GetText().CutText());
				row.AddCell(record.Ability1.GetName(record.AbilityValue1));
				row.AddCell(record.Ability2.GetName(record.AbilityValue2));
				row.AddCell(record.Ability3.GetName(record.AbilityValue3));
				row.AddCell(record.Ability4.GetName(record.AbilityValue4));
				row.AddCell(record.Ability5.GetName(record.AbilityValue5));


				//获取目标讯息
				row.AddCell(record.Unknown ? record.Attributes["item-count-1"] : " / ");

				for (int i = 1; i <= 20; i++)
				{
					if (!record.ContainsAttribute("item-" + i, out string Item)) break;

					string TimeInfo = record.Unknown ? "" : record.Attributes["item-count-" + i] + "次";
					row.AddCell($"{Item.GetName()} {TimeInfo}");
				}
			}
		}
	}
}