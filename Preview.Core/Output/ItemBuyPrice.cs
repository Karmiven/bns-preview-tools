using System.Linq;

using Xylia.Extension;
using Xylia.Files.Excel;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls.Currency;

namespace Xylia.Preview.Output
{
	public sealed class ItemBuyPrice : OutBase
	{
		protected override string Name => "物品购买价格";

		protected override void CreateData()
		{
			#region Title
			this.ExcelInfo.SetColumn("alias", 70);
			this.ExcelInfo.SetColumn("钱币", 15);
			this.ExcelInfo.SetColumn("物品组", 20);
			this.ExcelInfo.SetColumn("物品1", 25);
			this.ExcelInfo.SetColumn("物品2", 25);
			this.ExcelInfo.SetColumn("物品3", 25);
			this.ExcelInfo.SetColumn("物品4", 25);
			this.ExcelInfo.SetColumn("灵气");
			this.ExcelInfo.SetColumn("仙豆");
			this.ExcelInfo.SetColumn("龙果");
			this.ExcelInfo.SetColumn("仙桃");
			this.ExcelInfo.SetColumn("珍珠");
			this.ExcelInfo.SetColumn("满足成就点数");
			this.ExcelInfo.SetColumn("满足完成成就");
			this.ExcelInfo.SetColumn("满足势力等级");
			this.ExcelInfo.SetColumn("满足个人战比武等级");
			this.ExcelInfo.SetColumn("满足车轮战比武等级");
			this.ExcelInfo.SetColumn("满足升龙谷等级");
			this.ExcelInfo.SetColumn("满足白鲸湖等级");
			this.ExcelInfo.SetColumn("满足银河遗迹等级");
			this.ExcelInfo.SetColumn("限购设置");
			#endregion


			FileCache.Data.ItemBuyPrice.ForEach(Info =>
			{
				var row = this.ExcelInfo.CreateRow();
				row.AddCell(Info.alias);
				row.AddCell(new MoneyConvert(Info.Money).ToString(false));

				#region RequiredItembrand
				var ItemBrand = FileCache.Data.ItemBrand[Info.RequiredItembrand];

				var Type = Info.RequiredItembrandConditionType;
				if (Type == ConditionType.None) Type = ConditionType.All;
				var ItemTooltip = FileCache.Data.ItemBrandTooltip[ItemBrand?.Key() ?? 0, (byte)Type];

				row.AddCell(ItemTooltip?.Name2.GetText() ?? Info.RequiredItembrand);
				#endregion

				#region RequiredItem
				void GetRequiredItem(Item RequiredItem, short RequiredItemCount)
				{
					if (RequiredItem is null) row.AddCell("");
					else
					{
						string ItemName = FileCache.Data.Item[RequiredItem]?.Name2 ?? RequiredItem.alias;
						row.AddCell(ItemName + GetCount(RequiredItemCount));
					}
				}

				GetRequiredItem(Info.RequiredItem1, Info.RequiredItemCount1);
				GetRequiredItem(Info.RequiredItem2, Info.RequiredItemCount2);
				GetRequiredItem(Info.RequiredItem3, Info.RequiredItemCount3);
				GetRequiredItem(Info.RequiredItem4, Info.RequiredItemCount4);
				#endregion

				row.AddCell(Info.RequiredFactionScore, DisplayType.HideValue);
				row.AddCell(Info.RequiredDuelPoint, DisplayType.HideValue);
				row.AddCell(Info.RequiredPartyBattlePoint, DisplayType.HideValue);
				row.AddCell(Info.RequiredFieldPlayPoint, DisplayType.HideValue);
				row.AddCell(Info.RequiredLifeContentsPoint, DisplayType.HideValue);
				row.AddCell(Info.RequiredAchievementScore, DisplayType.HideValue);

				#region 获取成就名称
				string AchievementName = Info.RequiredAchievementId == 0 ? null : 
				    FileCache.Data.Achievement.FirstOrDefault(o => o.Key() == Info.RequiredAchievementId && o.Step == Info.RequiredAchievementStepMin)?.Name.GetText();
				row.AddCell(AchievementName);
				#endregion

				row.AddCell(Info.FactionLevel, DisplayType.HideValue);
				row.AddCell(Info.CheckSoloDuelGrade, DisplayType.HideValue);
				row.AddCell(Info.CheckTeamDuelGrade, DisplayType.HideValue);
				row.AddCell(Info.CheckBattleFieldGradeOccupationWar, DisplayType.HideValue);
				row.AddCell(Info.CheckBattleFieldGradeCaptureTheFlag, DisplayType.HideValue);
				row.AddCell(Info.CheckBattleFieldGradeLeadTheBall, DisplayType.HideValue);
				row.AddCell(Info.CheckContentQuota);
			});
		}
	}
}