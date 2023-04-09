using Xylia.Extension;
using Xylia.Files.Excel;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Record;

using static Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Output
{
	public sealed class ItemCloset_Main : OutBase
	{
		protected override string Name => "Item_closet";

		protected override void CreateData()
		{
			#region Title
			this.ExcelInfo.SetColumn("物品编号", 15);
			this.ExcelInfo.SetColumn("物品别名", 40);
			this.ExcelInfo.SetColumn("物品名称", 25);
			this.ExcelInfo.SetColumn("装备类型", 15);
			this.ExcelInfo.SetColumn("性别", 15);
			this.ExcelInfo.SetColumn("种族", 15);
			this.ExcelInfo.SetColumn("衣柜归属", 20);
			this.ExcelInfo.SetColumn("衣柜目录", 20);
			#endregion

			FileCache.Data.Item.ForEach(ItemInfo =>
			{
				#region Initialize
				//指示是否需要输出
				bool Flag = false;

				//对于服装类型, 不需要额外判断
				if (ItemInfo.Type == ItemType.Costume) Flag = true;
				//对于武器类型, 需要判断是否存在衣柜关联
				else if (ItemInfo.Type == ItemType.Weapon && ItemInfo.ClosetGroupId != 0) Flag = true;
				//对于饰品, 需要判断其饰品类型
				else if (ItemInfo.Type == ItemType.Accessory &&
					(ItemInfo.AccessoryType == AccessoryTypeSeq.CostumeAttach || ItemInfo.AccessoryType == AccessoryTypeSeq.Vehicle)) Flag = true;


				if (!Flag) return;
				else if (ItemInfo.UsableDuration != 0) return;  //过滤所有期限型物品
				#endregion

				var row = this.ExcelInfo.CreateRow();
				row.AddCell(ItemInfo.Key());
				row.AddCell(ItemInfo.alias);
				row.AddCell(ItemInfo.Name2);
				row.AddCell(ItemInfo.EquipType.GetName());
				row.AddCell(ItemInfo.EquipSex.GetName());
				row.AddCell(ItemInfo.EquipRace.GetName());
				row.AddCell(ItemInfo.ClosetGroupId);

				if (ItemInfo.ClosetGroupId != 0)
				{
					var ClosetGroup = FileCache.Data.ClosetGroup[ItemInfo.ClosetGroupId];
					if (ClosetGroup != null) row.AddCell($"Name.closet-group.category.{ClosetGroup.Attributes["category"]}".GetText());
				}
			});
		}
	}
}