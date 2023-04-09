using System.Collections.Generic;
using System.Drawing;

using Xylia.Extension;

using static Xylia.Preview.Resources.Resource_BNSR;

namespace Xylia.Match.Windows.Panel
{
	/// <summary>
	/// 合成器
	/// </summary>
	public sealed class ItemImageCompose
	{
		#region Events & Delegates
		public event EmptyHandler RefreshHandle;
		public void Refresh() => this.RefreshHandle?.Invoke();
		#endregion

		#region Functions
		public Bitmap GradeImage;

		public ImageInfo BottomLeft;

		public ImageInfo TopRight;

		public Bitmap Icon;

		public Bitmap DrawICON(double? Ratio = null)
		{
			Bitmap Temp = new(GradeImage);

			//比例缩放
			if (Ratio != null) Temp = Temp.Thumbnail((double)Ratio);

			if (Icon != null) Temp = Temp.Combine(Icon, DrawLocation.Centre);


			if (BottomLeft?.bitmap != null)
			{
				var tmp = BottomLeft.bitmap;
				if (Ratio != null) tmp = BottomLeft.bitmap.Thumbnail((double)Ratio);

				Temp = Temp.Combine(tmp, DrawLocation.BottomLeft);
			}

			if (TopRight?.bitmap != null) Temp = Temp.Combine(TopRight.bitmap, DrawLocation.TopRight);


			return Temp;
		}
		#endregion
	}

	/// <summary>
	/// 合成选项
	/// </summary>
	public class CombineOption
	{
		public static List<GradeInfo> Grades = new()
		{
			{ new(1, "粗糙级") },
			{ new(2, "凡品级") },
			{ new(3, "奇巧级") },
			{ new(4, "精粹级") },
			{ new(5, "至尊级") },
			{ new(6, "进化级") },
			{ new(7, "传说级") },
			{ new(8, "古代级") },
			{ new(9, "神话级") },
		};

		public static List<ImageInfo> BLImage = new()
		{
			{ new("无附加属性", null) },
			{ new("封印", Weapon_Lock_04) },
			{ new("旧物", Weapon_Lock_05) },
			{ new("蓝色锁", unuseable_lock) },
			{ new("绿色锁", unuseable_lock_2) },
			{ new("绿色锁", Weapon_Lock_03) },
			{ new("橘色锁", Weapon_Lock_06) },
			{ new("禁止使用", Weapon_Lock_01) },
			{ new("无法使用", Weapon_Lock_02) },
		};

		public static List<ImageInfo> TRImage = new()
		{
			{ new("无交易属性", null) },
			{ new("拍卖行交易", SlotItem_marketBusiness) },
			{ new("账号通用", SlotItem_privateSale) },
		};
	}



	public sealed class GradeInfo
	{
		public GradeInfo(byte ItemGrade, string Name)
		{
			this.Name = Name;
			this.ItemGrade = ItemGrade;
		}


		public string Name;

		public byte ItemGrade = 1;
	}

	public sealed class ImageInfo
	{
		public ImageInfo(string Name, Bitmap bitmap)
		{
			this.Name = Name;
			this.bitmap = bitmap;
		}


		public string Name;

		public Bitmap bitmap;
	}
}