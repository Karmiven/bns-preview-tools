using System;
using System.Drawing;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Package.Pak;

namespace Xylia.Preview.Data.Record
{
	[AliasRecord]
	public sealed class IconTexture : BaseRecord
	{
		#region 属性字段
		[Signal("icon-texture")]
		public string iconTexture;

		[Signal("icon-height")]
		public short IconHeight;

		[Signal("icon-width")]
		public short IconWidth;

		[Signal("texture-height")]
		public short TextureHeight;

		[Signal("texture-width")]
		public short TextureWidth;
		#endregion


		#region 方法
		public Bitmap GetIcon(short IconIndex)
		{
			Bitmap TextureData = GetTextureData();
			if (TextureData is null) return null;

			#region 裁剪内容
			if (this.TextureWidth == this.IconWidth && this.TextureHeight == this.IconHeight)
				return TextureData;

			//获取行数与列数
			int AmountRow = this.TextureWidth / this.IconWidth;

			int RowID = IconIndex % AmountRow;
			int ColID = IconIndex / AmountRow;

			//计算行列索引
			//整除表示是最后一个对象
			if (RowID == 0) RowID = AmountRow;
			else ColID += 1;

			//System.Diagnostics.Debug.WriteLine($"{IconIndex} => {ColID} - {RowID}");

			//返回裁剪结果
			//锁定对象，防止异步异常
			lock (TextureData)
			{
				try
				{
					return TextureData.Clone(new Rectangle(
						(RowID - 1) * this.IconWidth,
						(ColID - 1) * this.IconHeight,
						this.IconWidth, this.IconHeight), TextureData.PixelFormat);
				}
				catch
				{
					return null;
				}
			}
			#endregion
		}

		private Bitmap GetTextureData() => this.iconTexture.GetUObject().GetImage();
		#endregion
	}
}

public static class IconTextureExt
{
	public static Bitmap GetIcon(this string IconInfo)
	{
		GetInfo(IconInfo, out string TextureAlias, out short IconIndex);
		if (TextureAlias is null) return null;

		return GetIcon(TextureAlias, IconIndex);
	}

	public static Bitmap GetIcon(this string TextureAlias, short IconIndex) => FileCache.Data.IconTexture[TextureAlias]?.GetIcon(IconIndex);


	public static void GetInfo(this string IconInfo, out string TextureAlias, out short IconIndex)
	{
		//判断有效性
		TextureAlias = null;
		IconIndex = 0;
		if (string.IsNullOrWhiteSpace(IconInfo)) return;

		//获取图标序号
		if (IconInfo.Contains(','))
		{
			var IconSplit = IconInfo.Split(',');
			TextureAlias = IconSplit[0];

			if (short.TryParse(IconSplit[^1], out IconIndex)) return;
			else throw new Exception("获取序号失败: " + IconInfo);
		}

		TextureAlias = IconInfo;
		IconIndex = 1;
		return;
	}
}