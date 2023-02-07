using Xylia.Preview.Common.Extension;

namespace Xylia.Match.Windows.Panel
{
    partial class IconOperator
	{
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.Folder = new System.Windows.Forms.FolderBrowserDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.Button9 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.Switch_Mode = new HZH_Controls.Controls.UCSwitch();
			this.Label5 = new System.Windows.Forms.Label();
			this.FormatSelect = new HZH_Controls.Controls.Combox();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button2 = new System.Windows.Forms.Button();
			this.Btn_Search_3 = new System.Windows.Forms.Button();
			this.Label3 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.Btn_Search_2 = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Path_ResultPath = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Btn_Search_1 = new System.Windows.Forms.Button();
			this.Path_GameFolder = new System.Windows.Forms.TextBox();
			this.Footer = new HZH_Controls.Controls.UCSplitLabel();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.ComboBox3 = new HZH_Controls.Controls.Combox();
			this.ComboBox2 = new HZH_Controls.Controls.Combox();
			this.ComboBox1 = new HZH_Controls.Controls.Combox();
			this.Radio_128px = new HZH_Controls.Controls.UCRadioButton();
			this.Radio_64px = new HZH_Controls.Controls.UCRadioButton();
			this.ucCheckBox1 = new HZH_Controls.Controls.UCCheckBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Button4 = new System.Windows.Forms.Button();
			this.ImageCompose_Reset = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.GemPage = new System.Windows.Forms.TabPage();
			this.ucSwitch1 = new HZH_Controls.Controls.UCSwitch();
			this.Label6 = new System.Windows.Forms.Label();
			this.Button7 = new System.Windows.Forms.Button();
			this.Button6 = new System.Windows.Forms.Button();
			this.GemCircle = new Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel.Cell.GemCircle();
			this.Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.DEBUG = new System.Windows.Forms.ToolStripMenuItem();
			this.Tip = new System.Windows.Forms.ToolTip(this.components);
			this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.Open = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.GemPage.SuspendLayout();
			this.Menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.AllowDrop = true;
			this.tabControl1.Controls.Add(this.TabPage1);
			this.tabControl1.Controls.Add(this.TabPage2);
			this.tabControl1.Controls.Add(this.GemPage);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.Padding = new System.Drawing.Point(6, 8);
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(789, 453);
			this.tabControl1.TabIndex = 13;
			// 
			// TabPage1
			// 
			this.TabPage1.AllowDrop = true;
			this.TabPage1.BackColor = System.Drawing.Color.White;
			this.TabPage1.Controls.Add(this.groupBox2);
			this.TabPage1.Controls.Add(this.groupBox1);
			this.TabPage1.Controls.Add(this.Btn_Search_3);
			this.TabPage1.Controls.Add(this.Label3);
			this.TabPage1.Controls.Add(this.TextBox1);
			this.TabPage1.Controls.Add(this.Btn_Search_2);
			this.TabPage1.Controls.Add(this.Label2);
			this.TabPage1.Controls.Add(this.Path_ResultPath);
			this.TabPage1.Controls.Add(this.Label1);
			this.TabPage1.Controls.Add(this.Btn_Search_1);
			this.TabPage1.Controls.Add(this.Path_GameFolder);
			this.TabPage1.Controls.Add(this.Footer);
			this.TabPage1.Location = new System.Drawing.Point(4, 36);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Size = new System.Drawing.Size(781, 413);
			this.TabPage1.TabIndex = 2;
			this.TabPage1.Text = "道具图标";
			this.TabPage1.DragDrop += new System.Windows.Forms.DragEventHandler(this.IconOperator_DragDrop);
			this.TabPage1.DragEnter += new System.Windows.Forms.DragEventHandler(this.IconOperator_DragEnter);
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.Button9);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox2.Location = new System.Drawing.Point(7, 222);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(309, 121);
			this.groupBox2.TabIndex = 111;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "其他";
			// 
			// Button9
			// 
			this.Button9.Location = new System.Drawing.Point(19, 35);
			this.Button9.Name = "Button9";
			this.Button9.Size = new System.Drawing.Size(108, 44);
			this.Button9.TabIndex = 109;
			this.Button9.Text = "输出商品图标";
			this.Button9.Click += new System.EventHandler(this.Button9_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.Switch_Mode);
			this.groupBox1.Controls.Add(this.Label5);
			this.groupBox1.Controls.Add(this.FormatSelect);
			this.groupBox1.Controls.Add(this.Button1);
			this.groupBox1.Controls.Add(this.Button2);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox1.Location = new System.Drawing.Point(340, 223);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(418, 157);
			this.groupBox1.TabIndex = 110;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "物品图标库";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.BackColor = System.Drawing.Color.Transparent;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(150, 96);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(99, 21);
			this.checkBox1.TabIndex = 112;
			this.checkBox1.Text = "包含品质背景";
			this.checkBox1.UseVisualStyleBackColor = false;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			this.checkBox1.MouseEnter += new System.EventHandler(this.Switch_HasBG_MouseEnter);
			this.checkBox1.MouseLeave += new System.EventHandler(this.Switch_HasBG_MouseLeave);
			// 
			// Switch_Mode
			// 
			this.Switch_Mode.BackColor = System.Drawing.Color.Transparent;
			this.Switch_Mode.Checked = true;
			this.Switch_Mode.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
			this.Switch_Mode.FalseTextColr = System.Drawing.Color.White;
			this.Switch_Mode.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Switch_Mode.ForeColor = System.Drawing.Color.Black;
			this.Switch_Mode.Location = new System.Drawing.Point(19, 96);
			this.Switch_Mode.Name = "Switch_Mode";
			this.Switch_Mode.Size = new System.Drawing.Size(109, 40);
			this.Switch_Mode.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
			this.Switch_Mode.TabIndex = 100;
			this.Switch_Mode.Texts = new string[] {
        "过滤列表",
        "按照列表"};
			this.Switch_Mode.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Switch_Mode.TrueTextColr = System.Drawing.Color.Black;
			this.Switch_Mode.CheckedChanged += new System.EventHandler(this.Switch_Mode_CheckedChanged);
			this.Switch_Mode.MouseEnter += new System.EventHandler(this.Switch_Mode_MouseEnter);
			this.Switch_Mode.MouseLeave += new System.EventHandler(this.Switch_HasBG_MouseLeave);
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(21, 25);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(80, 17);
			this.Label5.TabIndex = 106;
			this.Label5.Text = "输出格式选择";
			this.Label5.MouseEnter += new System.EventHandler(this.FormatSelect_MouseEnter);
			this.Label5.MouseLeave += new System.EventHandler(this.Switch_HasBG_MouseLeave);
			// 
			// FormatSelect
			// 
			this.FormatSelect.BackColor = System.Drawing.Color.Transparent;
			this.FormatSelect.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.FormatSelect.ConerRadius = 10;
			this.FormatSelect.DropPanelHeight = -1;
			this.FormatSelect.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.FormatSelect.IsRadius = true;
			this.FormatSelect.IsShowRect = true;
			this.FormatSelect.ItemWidth = 40;
			this.FormatSelect.Location = new System.Drawing.Point(19, 49);
			this.FormatSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.FormatSelect.Name = "FormatSelect";
			this.FormatSelect.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.FormatSelect.RectWidth = 1;
			this.FormatSelect.SelectedIndex = -1;
			this.FormatSelect.Size = new System.Drawing.Size(223, 32);
			this.FormatSelect.TabIndex = 108;
			this.FormatSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FormatSelect.TextValue = "[id]";
			this.FormatSelect.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.FormatSelect.TextChangedEvent += new System.EventHandler(this.FormatSelect_TextChanged);
			this.FormatSelect.MouseEnter += new System.EventHandler(this.FormatSelect_MouseEnter);
			this.FormatSelect.MouseLeave += new System.EventHandler(this.Switch_HasBG_MouseLeave);
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(280, 27);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(112, 42);
			this.Button1.TabIndex = 28;
			this.Button1.Text = "导出已有列表";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button1.MouseEnter += new System.EventHandler(this.Button1_MouseEnter);
			this.Button1.MouseLeave += new System.EventHandler(this.Switch_HasBG_MouseLeave);
			// 
			// Button2
			// 
			this.Button2.Location = new System.Drawing.Point(280, 93);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(112, 42);
			this.Button2.TabIndex = 2;
			this.Button2.Text = "输出物品图标";
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// Btn_Search_3
			// 
			this.Btn_Search_3.Location = new System.Drawing.Point(597, 145);
			this.Btn_Search_3.Name = "Btn_Search_3";
			this.Btn_Search_3.Size = new System.Drawing.Size(75, 23);
			this.Btn_Search_3.TabIndex = 26;
			this.Btn_Search_3.Text = "浏览";
			this.Btn_Search_3.Click += new System.EventHandler(this.Btn_Search_3_Click);
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(3, 122);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(116, 17);
			this.Label3.TabIndex = 25;
			this.Label3.Text = "请选择物品缓存数据";
			// 
			// TextBox1
			// 
			this.TextBox1.Location = new System.Drawing.Point(3, 145);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(566, 23);
			this.TextBox1.TabIndex = 24;
			this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			// 
			// Btn_Search_2
			// 
			this.Btn_Search_2.Location = new System.Drawing.Point(597, 82);
			this.Btn_Search_2.Name = "Btn_Search_2";
			this.Btn_Search_2.Size = new System.Drawing.Size(75, 23);
			this.Btn_Search_2.TabIndex = 22;
			this.Btn_Search_2.Text = "浏览";
			this.Btn_Search_2.Click += new System.EventHandler(this.Btn_Search_2_Click);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(0, 60);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(101, 17);
			this.Label2.TabIndex = 21;
			this.Label2.Text = "请选择输出目录 *";
			// 
			// Path_ResultPath
			// 
			this.Path_ResultPath.Location = new System.Drawing.Point(3, 82);
			this.Path_ResultPath.Name = "Path_ResultPath";
			this.Path_ResultPath.Size = new System.Drawing.Size(566, 23);
			this.Path_ResultPath.TabIndex = 20;
			this.Path_ResultPath.TextChanged += new System.EventHandler(this.Path_ResultPath_TextChanged);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(3, 3);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(113, 17);
			this.Label1.TabIndex = 5;
			this.Label1.Text = "请选择游戏根目录 *";
			// 
			// Btn_Search_1
			// 
			this.Btn_Search_1.Location = new System.Drawing.Point(597, 25);
			this.Btn_Search_1.Name = "Btn_Search_1";
			this.Btn_Search_1.Size = new System.Drawing.Size(75, 23);
			this.Btn_Search_1.TabIndex = 4;
			this.Btn_Search_1.Text = "浏览";
			this.Btn_Search_1.Click += new System.EventHandler(this.Btn_Search_1_Click);
			// 
			// Path_GameFolder
			// 
			this.Path_GameFolder.Location = new System.Drawing.Point(3, 25);
			this.Path_GameFolder.Name = "Path_GameFolder";
			this.Path_GameFolder.Size = new System.Drawing.Size(566, 23);
			this.Path_GameFolder.TabIndex = 3;
			this.Path_GameFolder.TextChanged += new System.EventHandler(this.Path_GameFolder_TextChanged);
			// 
			// Footer
			// 
			this.Footer.AutoEllipsis = true;
			this.Footer.AutoSize = true;
			this.Footer.BackColor = System.Drawing.Color.Transparent;
			this.Footer.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Footer.LineColor = System.Drawing.Color.White;
			this.Footer.Location = new System.Drawing.Point(3, 387);
			this.Footer.MaximumSize = new System.Drawing.Size(0, 22);
			this.Footer.MinimumSize = new System.Drawing.Size(150, 22);
			this.Footer.Name = "Footer";
			this.Footer.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.Footer.Size = new System.Drawing.Size(150, 22);
			this.Footer.TabIndex = 35;
			this.Footer.Text = "信息提示";
			// 
			// TabPage2
			// 
			this.TabPage2.AllowDrop = true;
			this.TabPage2.BackColor = System.Drawing.Color.White;
			this.TabPage2.Controls.Add(this.ComboBox3);
			this.TabPage2.Controls.Add(this.ComboBox2);
			this.TabPage2.Controls.Add(this.ComboBox1);
			this.TabPage2.Controls.Add(this.Radio_128px);
			this.TabPage2.Controls.Add(this.Radio_64px);
			this.TabPage2.Controls.Add(this.ucCheckBox1);
			this.TabPage2.Controls.Add(this.pictureBox4);
			this.TabPage2.Controls.Add(this.Label4);
			this.TabPage2.Controls.Add(this.Button4);
			this.TabPage2.Controls.Add(this.ImageCompose_Reset);
			this.TabPage2.Controls.Add(this.pictureBox1);
			this.TabPage2.Location = new System.Drawing.Point(4, 36);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Size = new System.Drawing.Size(781, 413);
			this.TabPage2.TabIndex = 3;
			this.TabPage2.Text = "图标合成";
			this.TabPage2.DragDrop += new System.Windows.Forms.DragEventHandler(this.IconOperator_DragDrop);
			this.TabPage2.DragEnter += new System.Windows.Forms.DragEventHandler(this.IconOperator_DragEnter);
			// 
			// ComboBox3
			// 
			this.ComboBox3.BackColor = System.Drawing.Color.Transparent;
			this.ComboBox3.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox3.ConerRadius = 10;
			this.ComboBox3.DropPanelHeight = -1;
			this.ComboBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ComboBox3.IsRadius = true;
			this.ComboBox3.IsShowRect = true;
			this.ComboBox3.ItemWidth = 40;
			this.ComboBox3.Location = new System.Drawing.Point(12, 144);
			this.ComboBox3.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ComboBox3.Name = "ComboBox3";
			this.ComboBox3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.ComboBox3.RectWidth = 1;
			this.ComboBox3.SelectedIndex = -1;
			this.ComboBox3.Size = new System.Drawing.Size(163, 37);
			this.ComboBox3.TabIndex = 112;
			this.ComboBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ComboBox3.TextValue = "";
			this.ComboBox3.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ComboBox3.SelectedChangedEvent += new System.EventHandler(this.ComboBox3_TextChanged);
			// 
			// ComboBox2
			// 
			this.ComboBox2.BackColor = System.Drawing.Color.Transparent;
			this.ComboBox2.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox2.ConerRadius = 10;
			this.ComboBox2.DropPanelHeight = -1;
			this.ComboBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ComboBox2.IsRadius = true;
			this.ComboBox2.IsShowRect = true;
			this.ComboBox2.ItemWidth = 40;
			this.ComboBox2.Location = new System.Drawing.Point(12, 84);
			this.ComboBox2.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ComboBox2.Name = "ComboBox2";
			this.ComboBox2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.ComboBox2.RectWidth = 1;
			this.ComboBox2.SelectedIndex = -1;
			this.ComboBox2.Size = new System.Drawing.Size(163, 37);
			this.ComboBox2.TabIndex = 111;
			this.ComboBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ComboBox2.TextValue = "";
			this.ComboBox2.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ComboBox2.SelectedChangedEvent += new System.EventHandler(this.ComboBox2_TextChanged);
			// 
			// ComboBox1
			// 
			this.ComboBox1.BackColor = System.Drawing.Color.Transparent;
			this.ComboBox1.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox1.ConerRadius = 10;
			this.ComboBox1.DropPanelHeight = -1;
			this.ComboBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ComboBox1.IsRadius = true;
			this.ComboBox1.IsShowRect = true;
			this.ComboBox1.ItemWidth = 40;
			this.ComboBox1.Location = new System.Drawing.Point(12, 24);
			this.ComboBox1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.ComboBox1.RectWidth = 1;
			this.ComboBox1.SelectedIndex = -1;
			this.ComboBox1.Size = new System.Drawing.Size(163, 37);
			this.ComboBox1.TabIndex = 110;
			this.ComboBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ComboBox1.TextValue = "";
			this.ComboBox1.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.ComboBox1.SelectedChangedEvent += new System.EventHandler(this.ComboBox1_TextChanged);
			// 
			// Radio_128px
			// 
			this.Radio_128px.BackColor = System.Drawing.SystemColors.Window;
			this.Radio_128px.Checked = false;
			this.Radio_128px.GroupName = null;
			this.Radio_128px.Location = new System.Drawing.Point(642, 204);
			this.Radio_128px.Name = "Radio_128px";
			this.Radio_128px.Size = new System.Drawing.Size(85, 30);
			this.Radio_128px.TabIndex = 36;
			this.Radio_128px.TextValue = "128 px";
			// 
			// Radio_64px
			// 
			this.Radio_64px.BackColor = System.Drawing.SystemColors.Window;
			this.Radio_64px.Checked = true;
			this.Radio_64px.GroupName = null;
			this.Radio_64px.Location = new System.Drawing.Point(642, 168);
			this.Radio_64px.Name = "Radio_64px";
			this.Radio_64px.Size = new System.Drawing.Size(84, 30);
			this.Radio_64px.TabIndex = 35;
			this.Radio_64px.TextValue = "64   px";
			// 
			// ucCheckBox1
			// 
			this.ucCheckBox1.BackColor = System.Drawing.Color.Transparent;
			this.ucCheckBox1.Checked = true;
			this.ucCheckBox1.Location = new System.Drawing.Point(12, 222);
			this.ucCheckBox1.Name = "ucCheckBox1";
			this.ucCheckBox1.Padding = new System.Windows.Forms.Padding(1);
			this.ucCheckBox1.Size = new System.Drawing.Size(152, 30);
			this.ucCheckBox1.TabIndex = 33;
			this.ucCheckBox1.TextValue = "使用新版本背景";
			this.ucCheckBox1.CheckedChangeEvent += new System.EventHandler(this.ComboBox1_TextChanged);
			// 
			// pictureBox4
			// 
			this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox4.Location = new System.Drawing.Point(439, 39);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(128, 128);
			this.pictureBox4.TabIndex = 32;
			this.pictureBox4.TabStop = false;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(211, 12);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(176, 17);
			this.Label4.TabIndex = 31;
			this.Label4.Text = "将图片拖入窗体中即可载入数据";
			// 
			// Button4
			// 
			this.Button4.Location = new System.Drawing.Point(654, 106);
			this.Button4.Name = "Button4";
			this.Button4.Size = new System.Drawing.Size(75, 23);
			this.Button4.TabIndex = 30;
			this.Button4.Text = "存储为";
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			// 
			// ImageCompose_Reset
			// 
			this.ImageCompose_Reset.Location = new System.Drawing.Point(654, 62);
			this.ImageCompose_Reset.Name = "ImageCompose_Reset";
			this.ImageCompose_Reset.Size = new System.Drawing.Size(75, 23);
			this.ImageCompose_Reset.TabIndex = 29;
			this.ImageCompose_Reset.Text = "重置";
			this.ImageCompose_Reset.Click += new System.EventHandler(this.ImageCompose_Reset_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Location = new System.Drawing.Point(260, 65);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 64);
			this.pictureBox1.TabIndex = 24;
			this.pictureBox1.TabStop = false;
			// 
			// GemPage
			// 
			this.GemPage.AllowDrop = true;
			this.GemPage.BackColor = System.Drawing.Color.White;
			this.GemPage.Controls.Add(this.ucSwitch1);
			this.GemPage.Controls.Add(this.Label6);
			this.GemPage.Controls.Add(this.Button7);
			this.GemPage.Controls.Add(this.Button6);
			this.GemPage.Controls.Add(this.GemCircle);
			this.GemPage.Location = new System.Drawing.Point(4, 36);
			this.GemPage.Name = "GemPage";
			this.GemPage.Size = new System.Drawing.Size(781, 413);
			this.GemPage.TabIndex = 5;
			this.GemPage.Text = "八卦牌合成";
			this.GemPage.Click += new System.EventHandler(this.GemPage_Click);
			this.GemPage.DragDrop += new System.Windows.Forms.DragEventHandler(this.GemPage_DragDrop);
			this.GemPage.DragEnter += new System.Windows.Forms.DragEventHandler(this.GemPage_DragEnter);
			// 
			// ucSwitch1
			// 
			this.ucSwitch1.BackColor = System.Drawing.Color.Transparent;
			this.ucSwitch1.Checked = true;
			this.ucSwitch1.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
			this.ucSwitch1.FalseTextColr = System.Drawing.Color.White;
			this.ucSwitch1.Location = new System.Drawing.Point(3, 291);
			this.ucSwitch1.Name = "ucSwitch1";
			this.ucSwitch1.Size = new System.Drawing.Size(95, 40);
			this.ucSwitch1.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
			this.ucSwitch1.TabIndex = 109;
			this.ucSwitch1.Texts = new string[] {
        "背景 ",
        "无背景 "};
			this.ucSwitch1.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.ucSwitch1.TrueTextColr = System.Drawing.Color.Black;
			this.ucSwitch1.CheckedChanged += new System.EventHandler(this.ucSwitch1_CheckedChanged);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(278, 17);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(200, 17);
			this.Label6.TabIndex = 107;
			this.Label6.Text = "需要更改部位时，请点击对应的区域";
			// 
			// Button7
			// 
			this.Button7.Location = new System.Drawing.Point(655, 31);
			this.Button7.Name = "Button7";
			this.Button7.Size = new System.Drawing.Size(75, 23);
			this.Button7.TabIndex = 32;
			this.Button7.Text = "重置";
			this.Button7.Click += new System.EventHandler(this.Button7_Click);
			// 
			// Button6
			// 
			this.Button6.Location = new System.Drawing.Point(655, 75);
			this.Button6.Name = "Button6";
			this.Button6.Size = new System.Drawing.Size(75, 23);
			this.Button6.TabIndex = 31;
			this.Button6.Text = "存储为";
			this.Button6.Click += new System.EventHandler(this.Button6_Click);
			// 
			// GemCircle
			// 
			this.GemCircle.AutoSize = true;
			this.GemCircle.BackColor = System.Drawing.Color.Transparent;
			this.GemCircle.Location = new System.Drawing.Point(3, 3);
			this.GemCircle.Margin = new System.Windows.Forms.Padding(4);
			this.GemCircle.Meta1 = null;
			this.GemCircle.Meta2 = null;
			this.GemCircle.Meta3 = null;
			this.GemCircle.Meta4 = null;
			this.GemCircle.Meta5 = null;
			this.GemCircle.Meta6 = null;
			this.GemCircle.Meta7 = null;
			this.GemCircle.Meta8 = null;
			this.GemCircle.Name = "GemCircle";
			this.GemCircle.PartSel = Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel.Cell.GemCircle.PartSection.Part1;
			this.GemCircle.Size = new System.Drawing.Size(247, 249);
			this.GemCircle.TabIndex = 2;
			this.GemCircle.Transparent = false;
			this.GemCircle.WholeScale = 1F;
			this.GemCircle.SelectPartChanged += new System.EventHandler(this.GemCircle_SelectPartChanged);
			// 
			// Menu
			// 
			this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DEBUG});
			this.Menu.Name = "Menu";
			this.Menu.Size = new System.Drawing.Size(119, 26);
			// 
			// DEBUG
			// 
			this.DEBUG.Name = "DEBUG";
			this.DEBUG.Size = new System.Drawing.Size(118, 22);
			this.DEBUG.Text = "DEBUG";
			this.DEBUG.Visible = false;
			// 
			// IconOperator
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.tabControl1);
			this.Name = "IconOperator";
			this.Size = new System.Drawing.Size(789, 453);
			this.Load += new System.EventHandler(this.IconOperator_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.IconOperator_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.IconOperator_DragEnter);
			this.tabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.GemPage.ResumeLayout(false);
			this.GemPage.PerformLayout();
			this.Menu.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog Folder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button Btn_Search_1;
        private System.Windows.Forms.TextBox Path_GameFolder;
        private System.Windows.Forms.Button Btn_Search_2;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox Path_ResultPath;
        private System.Windows.Forms.ContextMenuStrip Menu;
        private System.Windows.Forms.Button Btn_Search_3;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.OpenFileDialog Open;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Button4;
        private System.Windows.Forms.Button ImageCompose_Reset;
        private System.Windows.Forms.Label Label4;
        private HZH_Controls.Controls.UCSplitLabel Footer;
        private HZH_Controls.Controls.UCSwitch Switch_Mode;
        private System.Windows.Forms.ToolStripMenuItem DEBUG;
		private System.Windows.Forms.PictureBox pictureBox4;
		private HZH_Controls.Controls.UCCheckBox ucCheckBox1;
		private HZH_Controls.Controls.UCRadioButton Radio_128px;
		private HZH_Controls.Controls.UCRadioButton Radio_64px;
		private System.Windows.Forms.Label Label5;
		private System.Windows.Forms.TabPage GemPage;
		private Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel.Cell.GemCircle GemCircle;
		private System.Windows.Forms.Button Button6;
		private System.Windows.Forms.Button Button7;
		private System.Windows.Forms.Label Label6;
		private HZH_Controls.Controls.UCSwitch ucSwitch1;
		private HZH_Controls.Controls.Combox FormatSelect;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button Button9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private HZH_Controls.Controls.Combox ComboBox3;
		private HZH_Controls.Controls.Combox ComboBox2;
		private HZH_Controls.Controls.Combox ComboBox1;
	}
}