using System;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Package.Pak;

namespace Xylia.Preview.GameUI.Controls
{
	/// <summary>
	/// 绘制参数
	/// </summary>
	public class ExecuteParam : ICloneable
	{
		#region Fields
		public Font Font;

		public Color ForeColor;

		public HorizontalAlignment HorizontalAlignment;
		#endregion

		#region 构造
		public ExecuteParam(Control c)
		{
			this.Font = c.Font;
			this.ForeColor = c.ForeColor;
		}
		#endregion


		/// <summary>
		/// 获取字体信息
		/// </summary>
		/// <param name="FontName"></param>
		/// <param name="UseFontHeight"></param>
		/// <returns></returns>
		public ExecuteParam GetFont(string FontName, bool UseFontHeight = true)
		{
			if (FontName is null) return this;

			var param = (ExecuteParam)this.Clone();

			// 提高处理速度
			if (Program.IsDesignMode && FontName.StartsWith("00008130.Program.Fontset_ItemGrade_"))
			{
				param.ForeColor = byte.Parse(FontName.Replace("00008130.Program.Fontset_ItemGrade_", null)).ItemGrade();
				return param;
			}


			#region	读取数据
			var UFontSet = FontName.GetUObject();
			if (UFontSet is not null)
			{
				var set = UFontSet.GetFont();

				// color
				if (set.Color != default) param.ForeColor = set.Color;

				// style
				var style = FontStyle.Regular;
				if (set.Italic) style |= FontStyle.Italic;
				if (set.Strokeout) style |= FontStyle.Strikeout;
				if (set.Underline) style |= FontStyle.Underline;

				// font
				float size = !UseFontHeight || set.Height == 0 ? param.Font.Size : set.Height;
				param.Font = new Font(param.Font.FontFamily, size, style);
			}

			return param;
			#endregion
		}


		#region ICloneable
		public object Clone() => this.MemberwiseClone();
		#endregion
	}

	public class ExecuteUnit
	{
		public ExecuteParam param;

		public PointF point;

		public int Width;


		public string text;

		public Bitmap bitmap;



		#region 构造
		public ExecuteUnit(ExecuteParam param, PointF point, string text)
		{
			this.param = param;
			this.point = point;
			this.text = text;
			this.Width = (int)text.MeasureString(param.Font).Width;
		}

		public ExecuteUnit(ExecuteParam param, PointF point, Bitmap bitmap)
		{
			this.param = param;
			this.point = point;
			this.bitmap = bitmap;
			this.Width = bitmap.Width;
		}
		#endregion
	}
}