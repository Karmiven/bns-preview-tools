namespace Xylia.Match.Windows.Forms
{
    partial class SettingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Folder = new System.Windows.Forms.FolderBrowserDialog();
			this.FolderTabPage = new System.Windows.Forms.TabPage();
			this.ucBtnFillet2 = new HZH_Controls.Controls.UCBtnFillet();
			this.lbl_Region = new System.Windows.Forms.Label();
			this.GRoot_Path = new System.Windows.Forms.TextBox();
			this.GRoot_Note = new System.Windows.Forms.Label();
			this.Faster_Folder_Path = new System.Windows.Forms.TextBox();
			this.Faster_Folder_Note = new System.Windows.Forms.Label();
			this.ucBtnFillet1 = new HZH_Controls.Controls.UCBtnFillet();
			this.SettingsTabControl = new System.Windows.Forms.TabControl();
			this.OptionTabPage = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Preview_DataTest = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.FolderTabPage.SuspendLayout();
			this.SettingsTabControl.SuspendLayout();
			this.OptionTabPage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Preview_DataTest)).BeginInit();
			this.SuspendLayout();
			// 
			// colorDialog1
			// 
			this.colorDialog1.AnyColor = true;
			this.colorDialog1.FullOpen = true;
			// 
			// FolderTabPage
			// 
			this.FolderTabPage.Controls.Add(this.ucBtnFillet2);
			this.FolderTabPage.Controls.Add(this.lbl_Region);
			this.FolderTabPage.Controls.Add(this.GRoot_Path);
			this.FolderTabPage.Controls.Add(this.GRoot_Note);
			this.FolderTabPage.Controls.Add(this.Faster_Folder_Path);
			this.FolderTabPage.Controls.Add(this.Faster_Folder_Note);
			this.FolderTabPage.Controls.Add(this.ucBtnFillet1);
			this.FolderTabPage.Location = new System.Drawing.Point(4, 36);
			this.FolderTabPage.Margin = new System.Windows.Forms.Padding(4);
			this.FolderTabPage.Name = "FolderTabPage";
			this.FolderTabPage.Padding = new System.Windows.Forms.Padding(4);
			this.FolderTabPage.Size = new System.Drawing.Size(487, 268);
			this.FolderTabPage.TabIndex = 4;
			this.FolderTabPage.Text = "目录";
			this.FolderTabPage.UseVisualStyleBackColor = true;
			// 
			// ucBtnFillet2
			// 
			this.ucBtnFillet2.BackColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet2.BtnImage = ((System.Drawing.Image)(resources.GetObject("ucBtnFillet2.BtnImage")));
			this.ucBtnFillet2.BtnText = "选择目录";
			this.ucBtnFillet2.ConerRadius = 10;
			this.ucBtnFillet2.FillColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet2.IsRadius = true;
			this.ucBtnFillet2.IsShowRect = true;
			this.ucBtnFillet2.Location = new System.Drawing.Point(363, 36);
			this.ucBtnFillet2.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ucBtnFillet2.Name = "ucBtnFillet2";
			this.ucBtnFillet2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ucBtnFillet2.RectWidth = 1;
			this.ucBtnFillet2.Size = new System.Drawing.Size(94, 37);
			this.ucBtnFillet2.TabIndex = 96;
			this.ucBtnFillet2.BtnClick += new System.EventHandler(this.button1_Click);
			// 
			// lbl_Region
			// 
			this.lbl_Region.AutoSize = true;
			this.lbl_Region.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbl_Region.Location = new System.Drawing.Point(184, 73);
			this.lbl_Region.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_Region.Name = "lbl_Region";
			this.lbl_Region.Size = new System.Drawing.Size(104, 17);
			this.lbl_Region.TabIndex = 16;
			this.lbl_Region.Text = "客户端所属区域：";
			this.lbl_Region.Visible = false;
			// 
			// GRoot_Path
			// 
			this.GRoot_Path.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.GRoot_Path.Location = new System.Drawing.Point(6, 42);
			this.GRoot_Path.Margin = new System.Windows.Forms.Padding(4);
			this.GRoot_Path.Name = "GRoot_Path";
			this.GRoot_Path.Size = new System.Drawing.Size(336, 23);
			this.GRoot_Path.TabIndex = 11;
			this.GRoot_Path.TextChanged += new System.EventHandler(this.GRoot_Path_TextChanged);
			// 
			// GRoot_Note
			// 
			this.GRoot_Note.AutoSize = true;
			this.GRoot_Note.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.GRoot_Note.Location = new System.Drawing.Point(7, 21);
			this.GRoot_Note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.GRoot_Note.Name = "GRoot_Note";
			this.GRoot_Note.Size = new System.Drawing.Size(56, 17);
			this.GRoot_Note.TabIndex = 13;
			this.GRoot_Note.Text = "游戏目录";
			// 
			// Faster_Folder_Path
			// 
			this.Faster_Folder_Path.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Faster_Folder_Path.Location = new System.Drawing.Point(6, 126);
			this.Faster_Folder_Path.Margin = new System.Windows.Forms.Padding(4);
			this.Faster_Folder_Path.Name = "Faster_Folder_Path";
			this.Faster_Folder_Path.Size = new System.Drawing.Size(336, 23);
			this.Faster_Folder_Path.TabIndex = 15;
			this.Faster_Folder_Path.TextChanged += new System.EventHandler(this.Faster_Folder_Path_TextChanged);
			// 
			// Faster_Folder_Note
			// 
			this.Faster_Folder_Note.AutoSize = true;
			this.Faster_Folder_Note.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Faster_Folder_Note.Location = new System.Drawing.Point(7, 105);
			this.Faster_Folder_Note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Faster_Folder_Note.Name = "Faster_Folder_Note";
			this.Faster_Folder_Note.Size = new System.Drawing.Size(56, 17);
			this.Faster_Folder_Note.TabIndex = 10;
			this.Faster_Folder_Note.Text = "输出目录";
			// 
			// ucBtnFillet1
			// 
			this.ucBtnFillet1.BackColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet1.BtnImage = ((System.Drawing.Image)(resources.GetObject("ucBtnFillet1.BtnImage")));
			this.ucBtnFillet1.BtnText = "选择目录";
			this.ucBtnFillet1.ConerRadius = 10;
			this.ucBtnFillet1.FillColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet1.IsRadius = true;
			this.ucBtnFillet1.IsShowRect = true;
			this.ucBtnFillet1.Location = new System.Drawing.Point(363, 119);
			this.ucBtnFillet1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ucBtnFillet1.Name = "ucBtnFillet1";
			this.ucBtnFillet1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ucBtnFillet1.RectWidth = 1;
			this.ucBtnFillet1.Size = new System.Drawing.Size(94, 37);
			this.ucBtnFillet1.TabIndex = 95;
			this.ucBtnFillet1.BtnClick += new System.EventHandler(this.Faster_Folder_Btn_Click);
			// 
			// SettingsTabControl
			// 
			this.SettingsTabControl.Controls.Add(this.FolderTabPage);
			this.SettingsTabControl.Controls.Add(this.OptionTabPage);
			this.SettingsTabControl.Location = new System.Drawing.Point(0, 0);
			this.SettingsTabControl.Margin = new System.Windows.Forms.Padding(4);
			this.SettingsTabControl.Multiline = true;
			this.SettingsTabControl.Name = "SettingsTabControl";
			this.SettingsTabControl.Padding = new System.Drawing.Point(6, 8);
			this.SettingsTabControl.SelectedIndex = 0;
			this.SettingsTabControl.Size = new System.Drawing.Size(495, 308);
			this.SettingsTabControl.TabIndex = 4;
			// 
			// OptionTabPage
			// 
			this.OptionTabPage.Controls.Add(this.groupBox1);
			this.OptionTabPage.Location = new System.Drawing.Point(4, 36);
			this.OptionTabPage.Name = "OptionTabPage";
			this.OptionTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.OptionTabPage.Size = new System.Drawing.Size(487, 268);
			this.OptionTabPage.TabIndex = 5;
			this.OptionTabPage.Text = "选项";
			this.OptionTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Preview_DataTest);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox1.Location = new System.Drawing.Point(6, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(270, 150);
			this.groupBox1.TabIndex = 100;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "测试模式";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// Preview_DataTest
			// 
			this.Preview_DataTest.BackColor = System.Drawing.Color.White;
			this.Preview_DataTest.LargeChange = 1;
			this.Preview_DataTest.Location = new System.Drawing.Point(110, 32);
			this.Preview_DataTest.Maximum = 2;
			this.Preview_DataTest.Name = "Preview_DataTest";
			this.Preview_DataTest.Size = new System.Drawing.Size(137, 45);
			this.Preview_DataTest.TabIndex = 101;
			this.Preview_DataTest.Scroll += new System.EventHandler(this.Preview_DataTest_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(20, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 20);
			this.label1.TabIndex = 101;
			this.label1.Text = "数据输出";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 312);
			this.Controls.Add(this.SettingsTabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.Padding = new System.Windows.Forms.Padding(23, 85, 23, 28);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "设置";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.MouseEnter += new System.EventHandler(this.SettingsForm_MouseEnter);
			this.FolderTabPage.ResumeLayout(false);
			this.FolderTabPage.PerformLayout();
			this.SettingsTabControl.ResumeLayout(false);
			this.OptionTabPage.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Preview_DataTest)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FolderBrowserDialog Folder;
		private System.Windows.Forms.TabPage FolderTabPage;
		private System.Windows.Forms.Label lbl_Region;
		private System.Windows.Forms.TextBox GRoot_Path;
		private System.Windows.Forms.Label GRoot_Note;
		private System.Windows.Forms.TextBox Faster_Folder_Path;
		private System.Windows.Forms.Label Faster_Folder_Note;
		private System.Windows.Forms.TabControl SettingsTabControl;
		private HZH_Controls.Controls.UCBtnFillet ucBtnFillet1;
		private HZH_Controls.Controls.UCBtnFillet ucBtnFillet2;
		private System.Windows.Forms.TabPage OptionTabPage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar Preview_DataTest;
	}
}