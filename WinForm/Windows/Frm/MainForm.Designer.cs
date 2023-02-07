namespace Xylia.Match.Windows
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tvMenu = new HZH_Controls.Controls.TreeViewEx();
			this.Memory = new System.Windows.Forms.Label();
			this.Panel = new System.Windows.Forms.Panel();
			this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenRes = new System.Windows.Forms.ToolStripMenuItem();
			this.Footer = new System.Windows.Forms.Label();
			this.Btn_log = new System.Windows.Forms.PictureBox();
			this.Btn_Set = new System.Windows.Forms.PictureBox();
			this.Btn_AboutUs = new System.Windows.Forms.PictureBox();
			this.tvMenu.SuspendLayout();
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Btn_log)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Btn_Set)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Btn_AboutUs)).BeginInit();
			this.SuspendLayout();
			// 
			// tvMenu
			// 
			this.tvMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
			this.tvMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tvMenu.Controls.Add(this.Memory);
			this.tvMenu.Dock = System.Windows.Forms.DockStyle.Left;
			this.tvMenu.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
			this.tvMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tvMenu.FullRowSelect = true;
			this.tvMenu.HideSelection = false;
			this.tvMenu.IsShowByCustomModel = true;
			this.tvMenu.IsShowTip = false;
			this.tvMenu.ItemHeight = 50;
			this.tvMenu.Location = new System.Drawing.Point(0, 61);
			this.tvMenu.LstTips = null;
			this.tvMenu.Name = "tvMenu";
			this.tvMenu.NodeBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(51)))));
			this.tvMenu.NodeDownPic = ((System.Drawing.Image)(resources.GetObject("tvMenu.NodeDownPic")));
			this.tvMenu.NodeForeColor = System.Drawing.Color.White;
			this.tvMenu.NodeHeight = 50;
			this.tvMenu.NodeIsShowSplitLine = true;
			this.tvMenu.NodeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
			this.tvMenu.NodeSelectedForeColor = System.Drawing.Color.White;
			this.tvMenu.NodeSplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
			this.tvMenu.NodeUpPic = ((System.Drawing.Image)(resources.GetObject("tvMenu.NodeUpPic")));
			this.tvMenu.ParentNodeCanSelect = true;
			this.tvMenu.ShowLines = false;
			this.tvMenu.ShowPlusMinus = false;
			this.tvMenu.ShowRootLines = false;
			this.tvMenu.Size = new System.Drawing.Size(146, 493);
			this.tvMenu.TabIndex = 8;
			this.tvMenu.TipFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tvMenu.TipImage = ((System.Drawing.Image)(resources.GetObject("tvMenu.TipImage")));
			// 
			// Memory
			// 
			this.Memory.AutoSize = true;
			this.Memory.BackColor = System.Drawing.Color.Transparent;
			this.Memory.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Memory.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Memory.ForeColor = System.Drawing.Color.MediumAquamarine;
			this.Memory.Location = new System.Drawing.Point(0, 473);
			this.Memory.Name = "Memory";
			this.Memory.Size = new System.Drawing.Size(126, 20);
			this.Memory.TabIndex = 81;
			this.Memory.Text = "   信息监控初始化";
			// 
			// Panel
			// 
			this.Panel.BackColor = System.Drawing.Color.Transparent;
			this.Panel.ContextMenuStrip = this.MainMenu;
			this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel.Location = new System.Drawing.Point(146, 61);
			this.Panel.Name = "Panel";
			this.Panel.Size = new System.Drawing.Size(824, 492);
			this.Panel.TabIndex = 9;
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFolder});
			this.MainMenu.Name = "Right";
			this.MainMenu.Size = new System.Drawing.Size(137, 26);
			// 
			// OpenFolder
			// 
			this.OpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("OpenFolder.Image")));
			this.OpenFolder.Name = "OpenFolder";
			this.OpenFolder.Size = new System.Drawing.Size(136, 22);
			this.OpenFolder.Text = "打开文件夹";
			this.OpenFolder.Click += new System.EventHandler(this.OpenFolder_Click);
			// 
			// OpenRes
			// 
			this.OpenRes.Name = "OpenRes";
			this.OpenRes.Size = new System.Drawing.Size(32, 19);
			// 
			// Footer
			// 
			this.Footer.BackColor = System.Drawing.Color.Transparent;
			this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Footer.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Footer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
			this.Footer.Location = new System.Drawing.Point(146, 530);
			this.Footer.Name = "Footer";
			this.Footer.Size = new System.Drawing.Size(824, 24);
			this.Footer.TabIndex = 80;
			this.Footer.Text = "剑灵资源检索工具     Powered by  雪依        2018~2023";
			this.Footer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Btn_log
			// 
			this.Btn_log.BackColor = System.Drawing.Color.Azure;
			this.Btn_log.Image = ((System.Drawing.Image)(resources.GetObject("Btn_log.Image")));
			this.Btn_log.InitialImage = ((System.Drawing.Image)(resources.GetObject("Btn_log.InitialImage")));
			this.Btn_log.Location = new System.Drawing.Point(51, 33);
			this.Btn_log.Name = "Btn_log";
			this.Btn_log.Size = new System.Drawing.Size(24, 23);
			this.Btn_log.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Btn_log.TabIndex = 0;
			this.Btn_log.TabStop = false;
			this.Btn_log.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// Btn_Set
			// 
			this.Btn_Set.BackColor = System.Drawing.Color.Azure;
			this.Btn_Set.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Set.Image")));
			this.Btn_Set.InitialImage = ((System.Drawing.Image)(resources.GetObject("Btn_Set.InitialImage")));
			this.Btn_Set.Location = new System.Drawing.Point(4, 32);
			this.Btn_Set.Name = "Btn_Set";
			this.Btn_Set.Size = new System.Drawing.Size(24, 24);
			this.Btn_Set.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Btn_Set.TabIndex = 82;
			this.Btn_Set.TabStop = false;
			this.Btn_Set.Click += new System.EventHandler(this.Set_Click);
			// 
			// Btn_AboutUs
			// 
			this.Btn_AboutUs.BackColor = System.Drawing.Color.Azure;
			this.Btn_AboutUs.Image = ((System.Drawing.Image)(resources.GetObject("Btn_AboutUs.Image")));
			this.Btn_AboutUs.InitialImage = ((System.Drawing.Image)(resources.GetObject("Btn_AboutUs.InitialImage")));
			this.Btn_AboutUs.Location = new System.Drawing.Point(99, 33);
			this.Btn_AboutUs.Name = "Btn_AboutUs";
			this.Btn_AboutUs.Size = new System.Drawing.Size(24, 23);
			this.Btn_AboutUs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.Btn_AboutUs.TabIndex = 84;
			this.Btn_AboutUs.TabStop = false;
			this.Btn_AboutUs.Click += new System.EventHandler(this.Btn_AboutUs_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(970, 554);
			this.ContextMenuStrip = this.MainMenu;
			this.Controls.Add(this.Btn_AboutUs);
			this.Controls.Add(this.Footer);
			this.Controls.Add(this.Btn_Set);
			this.Controls.Add(this.Btn_log);
			this.Controls.Add(this.Panel);
			this.Controls.Add(this.tvMenu);
			this.IsShowCloseBtn = true;
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.ShowIcon = true;
			this.ShowInTaskbar = true;
			this.Text = "主运行框架";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
			this.Controls.SetChildIndex(this.tvMenu, 0);
			this.Controls.SetChildIndex(this.Panel, 0);
			this.Controls.SetChildIndex(this.Btn_log, 0);
			this.Controls.SetChildIndex(this.Btn_Set, 0);
			this.Controls.SetChildIndex(this.Footer, 0);
			this.Controls.SetChildIndex(this.Btn_AboutUs, 0);
			this.tvMenu.ResumeLayout(false);
			this.tvMenu.PerformLayout();
			this.MainMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Btn_log)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Btn_Set)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Btn_AboutUs)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private HZH_Controls.Controls.TreeViewEx tvMenu;
		private System.Windows.Forms.Panel Panel;
		private System.Windows.Forms.PictureBox Btn_log;
		private System.Windows.Forms.ToolStripMenuItem Faction;
		private System.Windows.Forms.ToolStripMenuItem OpenRes;
		private System.Windows.Forms.ToolStripMenuItem OpenFolder;
		private System.Windows.Forms.Label Footer;
		private System.Windows.Forms.Label Memory;
		private System.Windows.Forms.PictureBox Btn_Set;
		private System.Windows.Forms.PictureBox Btn_AboutUs;
		private System.Windows.Forms.ContextMenuStrip MainMenu;
	}
}