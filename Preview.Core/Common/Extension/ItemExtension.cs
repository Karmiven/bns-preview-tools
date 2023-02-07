using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Scene.Game_Auction;
using Xylia.Preview.Resources;
using Xylia.Windows.CustomException;

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
		public static Bitmap GetIconWithGrade(this string IconInfo, byte ItemGrade)
		{
			if (string.IsNullOrWhiteSpace(IconInfo))
			{
				System.Diagnostics.Debug.WriteLine($"未设置图标");
				return null;
			}

			//获取底图
			var BackGroundImage = ItemGrade.GetBackGround(true);

			//返回结果数据
			Bitmap Raw = IconInfo.GetIcon();
			return Raw is null ? BackGroundImage : BackGroundImage.Combine(Raw);
		}


		/// <summary>
		/// 尝试获取道具信息，搜索失败则进行模糊搜索
		/// </summary>
		/// <param name="rule"></param>
		/// <param name="ShowList"></param>
		/// <returns></returns>
		public static Item GetItemInfo(this string rule, bool ShowList = false)
		{
			if (!rule.Contains('+') && int.TryParse(rule, out var id))
				return FileCache.Data.Item[id, 1];


			var data = FileCache.Data.Item[rule.Trim()];
			if (data is null)
			{
				BlockingCollection<Item> lst = new();
				Parallel.ForEach(FileCache.Data.Item, Info =>
				{
					string ItemName = Info.Name2;
					if (ItemName != null)
					{
						if (ShowList)
						{
							if (ItemName.IndexOf(rule, StringComparison.OrdinalIgnoreCase) < 0) return;
						}
						else if (ItemName != rule) return;

						lst.Add(Info);
					}
				});

				var ResultCount = lst.Count;
				if (ResultCount == 1) data = lst.First();
				else if (ResultCount > 0 && ShowList)
				{
					new Game_AuctionScene(rule).ShowDialog();
					throw new UserExitException();
				}
			}

			return data;
		}
	}
}
