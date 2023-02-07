namespace Xylia.Preview.GameUI.Scene.Game_Auction
{
	partial class Game_AuctionScene
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
			this.TreeView = new Xylia.Windows.Controls.TreeView();
			this.ItemList = new Xylia.Preview.GameUI.Controls.ListPreview();
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.Chk_Auctionable = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.ItemPreview_Search = new HZH_Controls.Controls.UCTextBoxEx();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// TreeView
			// 
			this.TreeView.BackColor = System.Drawing.Color.White;
			this.TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TreeView.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
			this.TreeView.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.TreeView.HotTracking = true;
			this.TreeView.Indent = 20;
			this.TreeView.ItemHeight = 30;
			this.TreeView.Location = new System.Drawing.Point(0, 49);
			this.TreeView.Margin = new System.Windows.Forms.Padding(4);
			this.TreeView.Name = "TreeView";
			this.TreeView.ShowLines = false;
			this.TreeView.Size = new System.Drawing.Size(260, 551);
			this.TreeView.TabIndex = 3;
			this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LoadData);
			// 
			// ItemList
			// 
			this.ItemList.AutoScroll = true;
			this.ItemList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
			this.ItemList.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ItemList.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ItemList.Location = new System.Drawing.Point(0, 49);
			this.ItemList.Margin = new System.Windows.Forms.Padding(4);
			this.ItemList.Name = "ItemList";
			this.ItemList.Size = new System.Drawing.Size(549, 551);
			this.ItemList.TabIndex = 4;
			this.ItemList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.Chk_Auctionable);
			this.panel1.Controls.Add(this.ItemList);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(265, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(549, 600);
			this.panel1.TabIndex = 2;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(483, 23);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(51, 21);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "倒序";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.LoadData);
			// 
			// Chk_Auctionable
			// 
			this.Chk_Auctionable.AutoSize = true;
			this.Chk_Auctionable.Location = new System.Drawing.Point(483, 3);
			this.Chk_Auctionable.Name = "Chk_Auctionable";
			this.Chk_Auctionable.Size = new System.Drawing.Size(63, 21);
			this.Chk_Auctionable.TabIndex = 5;
			this.Chk_Auctionable.Text = "可拍卖";
			this.Chk_Auctionable.UseVisualStyleBackColor = true;
			this.Chk_Auctionable.CheckedChanged += new System.EventHandler(this.LoadData);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.ItemPreview_Search);
			this.panel2.Controls.Add(this.TreeView);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(260, 600);
			this.panel2.TabIndex = 5;
			// 
			// ItemPreview_Search
			// 
			this.ItemPreview_Search.BackColor = System.Drawing.Color.Transparent;
			this.ItemPreview_Search.ConerRadius = 5;
			this.ItemPreview_Search.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ItemPreview_Search.DecLength = 2;
			this.ItemPreview_Search.FillColor = System.Drawing.Color.Empty;
			this.ItemPreview_Search.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
			this.ItemPreview_Search.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ItemPreview_Search.InputText = "";
			this.ItemPreview_Search.InputType = HZH_Controls.TextInputType.NotControl;
			this.ItemPreview_Search.IsFocusColor = true;
			this.ItemPreview_Search.IsRadius = true;
			this.ItemPreview_Search.IsShowClearBtn = true;
			this.ItemPreview_Search.IsShowKeyboard = false;
			this.ItemPreview_Search.IsShowRect = true;
			this.ItemPreview_Search.IsShowSearchBtn = true;
			this.ItemPreview_Search.KeyBoardType = HZH_Controls.Controls.KeyBoardType.Null;
			this.ItemPreview_Search.Location = new System.Drawing.Point(3, 4);
			this.ItemPreview_Search.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ItemPreview_Search.MaxValue = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.ItemPreview_Search.MinValue = new decimal(new int[] {
			1000000,
			0,
			0,
			-2147483648});
			this.ItemPreview_Search.Name = "ItemPreview_Search";
			this.ItemPreview_Search.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.ItemPreview_Search.PromptColor = System.Drawing.Color.Gray;
			this.ItemPreview_Search.PromptFont = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ItemPreview_Search.PromptText = "";
			this.ItemPreview_Search.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ItemPreview_Search.RectWidth = 1;
			this.ItemPreview_Search.RegexPattern = "";
			this.ItemPreview_Search.Size = new System.Drawing.Size(254, 39);
			this.ItemPreview_Search.TabIndex = 116;
			this.ItemPreview_Search.SearchClick += new System.EventHandler(this.LoadData);
			// 
			// Game_AuctionScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 600);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Game_AuctionScene";
			this.Text = "Game_AuctionScene";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Windows.Controls.TreeView TreeView;
		private Controls.ListPreview ItemList;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private HZH_Controls.Controls.UCTextBoxEx ItemPreview_Search;
		private System.Windows.Forms.CheckBox Chk_Auctionable;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}