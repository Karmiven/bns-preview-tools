using System.Collections.Generic;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls.List;
using Xylia.Preview.Resources;

namespace Xylia.Preview.GameUI.Scene.Game_RandomStore
{
	public partial class ItemDisplayListCell : ListCell
	{
		public readonly RandomStoreItemDisplay data;
		
		public readonly Item DisplayItem;

		public ItemDisplayListCell(RandomStoreItemDisplay Record) 
		{
			InitializeComponent();

			this.data = Record;
			this.DisplayItem = FileCache.Data.Item[Record.DisplayItem];


			var ItemIcon = DisplayItem.IconExtra;
			if (data.NewArrival) ItemIcon = ItemIcon.Combine(Resource_Common.SlotItem_New, DrawLocation.TopLeft);

			this.ItemShow.LoadData(DisplayItem, ItemIcon);
		}
	}

	/// <summary>
	/// 排序器
	/// </summary>
	public sealed class DisplayListCellSort : IComparer<ItemDisplayListCell>
	{
		public int Compare(ItemDisplayListCell x, ItemDisplayListCell y)
		{
			//判断是否是新物品
			if (!x.data.NewArrival && y.data.NewArrival) return 1;
			else if (x.data.NewArrival && !y.data.NewArrival) return -1;

			var Ix = x.DisplayItem;
			var Iy = y.DisplayItem;

			//判断物品品质（大的在前）
			if (Ix.ItemGrade != Iy.ItemGrade) return Iy.ItemGrade - Ix.ItemGrade;

			//判断物品种类（小的在前）
			if (Ix.GameCategory3 != Iy.GameCategory3) return Ix.GameCategory3 - Iy.GameCategory3;

			//最后判断顺序（小的在前）
			return (int)(x.data.TableIndex - y.data.TableIndex);
		}
	}
}