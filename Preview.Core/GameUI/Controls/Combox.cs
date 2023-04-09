// ***********************************************************************
// Assembly         : HZH_Controls
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCCombox.cs">
//     Copyright by Huang Zhenghui(黄正辉) All, QQ group:568015492 QQ:623128629 Email:623128629@qq.com
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
	/// <summary>
	/// Class UCCombox.
	/// Implements the <see cref="HZH_Controls.Controls.UCControlBase" />
	/// </summary>
	/// <seealso cref="HZH_Controls.Controls.UCControlBase" />
	[DefaultEvent("SelectedChangedEvent")]
	public partial class Combox : UCControlBase
	{
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="UCCombox" /> class.
		/// </summary>
		public Combox()
		{
			InitializeComponent();

			this.Refresh();
			base.BackColor = Color.Transparent;
		}
		#endregion



		#region Fields
		/// <summary>
		/// 文字颜色
		/// </summary>
		/// <value>The color of the fore.</value>
		/// <PermissionSet>
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// </PermissionSet>
		[Description("文字颜色"), Category("自定义")]
		public override Color ForeColor
		{
			get => base.ForeColor;
			set
			{
				base.ForeColor = value;

				lblInput.ForeColor = value;
				txtInput.ForeColor = value;
			}
		}

		/// <summary>
		/// 选中Event
		/// </summary>
		[Description("选中Event"), Category("自定义")]
		public event EventHandler SelectedChangedEvent;

		/// <summary>
		/// 文本改变Event
		/// </summary>
		[Description("文本改变Event"), Category("自定义")]
		public event EventHandler TextChangedEvent;

		/// <summary>
		/// The box style
		/// </summary>
		private ComboBoxStyle _BoxStyle = ComboBoxStyle.DropDown;

		/// <summary>
		/// 控件样式
		/// </summary>
		/// <value>The box style.</value>
		[Description("控件样式"), Category("自定义")]
		public ComboBoxStyle BoxStyle
		{
			get => _BoxStyle;
			set
			{
				_BoxStyle = value;
				if (value == ComboBoxStyle.DropDownList)
				{
					lblInput.Visible = true;
					txtInput.Visible = false;
				}
				else
				{
					lblInput.Visible = false;
					txtInput.Visible = true;
				}

				this.Refresh();
			}
		}

		/// <summary>
		/// The font
		/// </summary>
		private Font _Font = new Font("微软雅黑", 12);

		/// <summary>
		/// 字体
		/// </summary>
		/// <value>The font.</value>
		/// <PermissionSet>
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		/// </PermissionSet>
		[Description("字体"), Category("自定义")]
		public new Font Font
		{
			get => _Font;
			set
			{
				_Font = value;

				lblInput.Font = value;
				txtInput.Font = value;
				txtInput.PromptFont = value;

				this.txtInput.Location = new Point(this.txtInput.Location.X, (this.Height - txtInput.Height) / 2);
				this.lblInput.Location = new Point(this.lblInput.Location.X, (this.Height - lblInput.Height) / 2);
			}
		}


		/// <summary>
		/// 当使用边框时填充颜色, 当值为背景色或透明色或空值则不填充
		/// </summary>
		/// <value>The color of the fill.</value>
		[Obsolete("不再可用的属性")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Color FillColor { get => base.FillColor; set => base.FillColor = value; }


		/// <summary>
		/// 边框颜色
		/// </summary>
		/// <value>The color of the rect.</value>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new Color RectColor { get => base.RectColor; set => base.RectColor = value; }



		/// <summary>
		/// The text value
		/// </summary>
		private string _TextValue;

		/// <summary>
		/// 文字
		/// </summary>
		/// <value>The text value.</value>
		[Description("文字"), Category("自定义")]
		public string TextValue
		{
			get => _TextValue;
			set
			{
				_TextValue = value;

				if (lblInput.Text != value) lblInput.Text = value;
				if (txtInput.Text != value) txtInput.Text = value;
			}
		}

		/// <summary>
		/// 文本对齐方式
		/// </summary>
		public HorizontalAlignment TextAlign { get => this.txtInput.TextAlign; set => this.txtInput.TextAlign = value; }
		#endregion






		#region Source
		/// <summary>
		/// The source
		/// </summary>
		private List<string> _source = new List<string>();

		/// <summary>
		/// 数据源
		/// </summary>
		/// <value>The source.</value>
		[Description("数据源"), Category("自定义")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		public List<string> Source
		{
			get => _source;
			set
			{
				_source = value;

				_selectedIndex = -1;
				_selectedText = "";

				lblInput.Text = "";
				txtInput.Text = "";
			}
		}
		#endregion


		/// <summary>
		/// The selected index
		/// </summary>
		private int _selectedIndex = -1;

		/// <summary>
		/// 选中的数据下标
		/// </summary>
		/// <value>The index of the selected.</value>
		[Description("选中的数据下标"), Category("自定义")]
		public int SelectedIndex
		{
			get => _selectedIndex;
			set
			{
				if (value < 0 || _source == null || _source.Count <= 0 || value >= _source.Count)
				{
					_selectedIndex = -1;
					SelectedText = "";
				}
				else
				{
					_selectedIndex = value;
					SelectedText = _source[value];
				}
			}
		}

		/// <summary>
		/// The selected text
		/// </summary>
		private string _selectedText = "";

		/// <summary>
		/// 选中的文本
		/// </summary>
		/// <value>The selected text.</value>
		[Description("选中的文本"), Category("自定义")]
		public string SelectedText
		{
			get => _selectedText;
			private set
			{
				_selectedText = value;

				lblInput.Text = _selectedText;
				txtInput.Text = _selectedText;

				this.SelectedChangedEvent?.Invoke(this, null);
			}
		}

		/// <summary>
		/// The item width
		/// </summary>
		private int _ItemWidth = 70;

		/// <summary>
		/// 项宽度
		/// </summary>
		/// <value>The width of the item.</value>
		[Description("项宽度"), Category("自定义")]
		public int ItemWidth { get => _ItemWidth; set => _ItemWidth = value; }

		/// <summary>
		/// The drop panel height
		/// </summary>
		private int _dropPanelHeight = -1;
		/// <summary>
		/// 下拉面板高度
		/// </summary>
		/// <value>The height of the drop panel.</value>
		[Description("下拉面板高度"), Category("自定义")]
		public int DropPanelHeight { get => _dropPanelHeight; set => _dropPanelHeight = value; }


		/// <summary>
		/// 背景色
		/// </summary>
		/// <value>The back color ext.</value>
		[Description("背景色"), Category("自定义")]
		public override Color BackColor
		{
			get => base.BackColor;
			set
			{
				base.BackColor = value;
				base.FillColor = BackColor;
				base.RectColor = BackColor;

				this.Refresh();
			}
		}

		public override void Refresh()
		{
			base.Refresh();

			if (BackColor != Color.Transparent)
			{
				lblInput.BackColor = BackColor;
				txtInput.BackColor = BackColor;
			}
		}



		/// <summary>
		/// The triangle color
		/// </summary>
		private Color triangleColor = Color.FromArgb(255, 77, 59);

		/// <summary>
		/// 三角颜色
		/// </summary>
		/// <value>The color of the triangle.</value>
		[Description("三角颜色"), Category("自定义")]
		public Color TriangleColor
		{
			get => triangleColor;
			set
			{
				triangleColor = value;
				Bitmap bit = new Bitmap(12, 10);
				Graphics g = Graphics.FromImage(bit);
				g.SetGDIHigh();
				GraphicsPath path = new GraphicsPath();
				path.AddLines(new Point[]
				{
					new Point(1,1),
					new Point(11,1),
					new Point(6,10),
					new Point(1,1)
				});
				g.FillPath(new SolidBrush(value), path);
				g.Dispose();
				panel1.BackgroundImage = bit;
			}
		}


		/// <summary>
		/// Handles the SizeChanged event of the UCComboBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		private void UCComboBox_SizeChanged(object sender, EventArgs e)
		{
			this.txtInput.Location = new Point(this.txtInput.Location.X, (this.Height - txtInput.Height) / 2);
			this.lblInput.Location = new Point(this.lblInput.Location.X, (this.Height - lblInput.Height) / 2);
		}

		/// <summary>
		/// Handles the TextChanged event of the txtInput control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		private void txtInput_TextChanged(object sender, EventArgs e)
		{
			TextValue = txtInput.Text;
			if (TextChangedEvent != null) TextChangedEvent(this, null);
		}

		/// <summary>
		/// Handles the MouseDown event of the click control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
		protected virtual void click_MouseDown(object sender, MouseEventArgs e)
		{
			if (_frmAnchor == null || _frmAnchor.IsDisposed || _frmAnchor.Visible == false)
			{
				if (this._source != null && this._source.Count > 0)
				{
					int intRow = 0;
					int intCom = 1;
					var p = this.PointToScreen(this.Location);

					while (true)
					{
						int intScreenHeight = Screen.PrimaryScreen.Bounds.Height;
						if ((p.Y + this.Height + this._source.Count / intCom * 50 < intScreenHeight || p.Y - this._source.Count / intCom * 50 > 0)
							&& (_dropPanelHeight <= 0 ? true : (this._source.Count / intCom * 50 <= _dropPanelHeight)))
						{
							intRow = this._source.Count / intCom + (this._source.Count % intCom != 0 ? 1 : 0);
							break;
						}
						intCom++;
					}

					UCTimePanel ucTime = new UCTimePanel();
					ucTime.IsShowBorder = true;
					int intWidth = this.Width / intCom;
					if (intWidth < _ItemWidth) intWidth = _ItemWidth;

					Size size = new Size(intCom * intWidth, intRow * 50);
					ucTime.Size = size;
					ucTime.FirstEvent = true;
					ucTime.SelectSourceEvent += ucTime_SelectSourceEvent;
					ucTime.Row = intRow;
					ucTime.Column = intCom;


					ucTime.Source = this._source.Select(o => new KeyValuePair<string, string>(o, o)).ToList();
					ucTime.SetSelect(this.SelectedText);


					_frmAnchor = new Forms.FrmAnchor(this, ucTime);
					_frmAnchor.Load += (a, b) => { (a as Form).Size = size; };

					_frmAnchor.Show(this.FindForm());
				}
			}
			else
			{
				_frmAnchor.Close();
			}
		}


		/// <summary>
		/// The FRM anchor
		/// </summary>
		Forms.FrmAnchor _frmAnchor;

		/// <summary>
		/// Handles the SelectSourceEvent event of the ucTime control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		void ucTime_SelectSourceEvent(object sender, EventArgs e)
		{
			if (_frmAnchor != null && !_frmAnchor.IsDisposed && _frmAnchor.Visible)
			{
				SelectedText = sender.ToString();
				_frmAnchor.Close();
			}
		}

		/// <summary>
		/// Handles the Load event of the UCComboBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		private void UCComboBox_Load(object sender, EventArgs e)
		{
			this.Refresh();
		}
	}
}
