using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Resources;

namespace Xylia.Preview.Common.Extension
{
	public static class ItemExtension
	{
		/// <summary>
		/// 返回品级对应的背景框
		/// </summary>
		/// <param name="Grade">物品品级</param>
		/// <param name="IsUE4"></param>
		/// <returns></returns>
		public static Bitmap GetBackGround(this byte Grade, bool IsUE4 = true) => Grade switch
		{
			2 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_2 : Resource_Common.ItemIcon_Bg_Grade_2,
			3 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_3 : Resource_Common.ItemIcon_Bg_Grade_3,
			4 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_4 : Resource_Common.ItemIcon_Bg_Grade_4,
			5 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_5 : Resource_Common.ItemIcon_Bg_Grade_5,
			6 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_6 : Resource_Common.ItemIcon_Bg_Grade_6,
			7 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_7 : Resource_Common.ItemIcon_Bg_Grade_7,
			8 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_8 : Resource_Common.ItemIcon_Bg_Grade_9,
			9 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_9 : Resource_Common.ItemIcon_Bg_Grade_8,

			1 or _ => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_1 : Resource_Common.ItemIcon_Bg_Grade_1,
		};

		/// <summary>
		/// 获得图标信息（包含品质）
		/// </summary>
		/// <param name="IconInfo"></param>
		/// <param name="ItemGrade"></param>
		/// <returns></returns>
		public static Bitmap GetIconWithGrade(this string IconInfo, byte Grade) => string.IsNullOrWhiteSpace(IconInfo) ? null :
			Grade.GetBackGround(true).Combine(IconInfo.GetIcon());

		public static List<Item> GetItemInfo(this string rule, bool UseExt = false)
		{
			Item data;
			if (!rule.Contains('+') && int.TryParse(rule, out var id)) data = FileCache.Data.Item[id, 1];
			else data = FileCache.Data.Item[rule.Trim()];
			if (data != null) return new() { data };


			BlockingCollection<Item> lst = new();
			Parallel.ForEach(FileCache.Data.Item, Info =>
			{
				var ItemName = Info.Name2;
				if (ItemName != null)
				{
					if (UseExt)
					{
						if (ItemName.IndexOf(rule, StringComparison.OrdinalIgnoreCase) < 0) return;
					}
					else if (ItemName != rule) return;

					lst.Add(Info);
				}
			});

			return lst.ToList();
		}
	}
}