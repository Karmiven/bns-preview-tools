namespace Xylia.Match.Windows.Attribute
{
	partial class MainFrm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源, 为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的Functions - 不要修改
		/// 使用代码编辑器修改此Functions的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("默认数据");
			Btn_Start = new System.Windows.Forms.Button();
			AttritubeValue = new System.Windows.Forms.TextBox();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			Label2 = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			AttritubeValue_Extra = new System.Windows.Forms.TextBox();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			NewItem = new System.Windows.Forms.ToolStripMenuItem();
			label1 = new System.Windows.Forms.Label();
			UseCompare = new System.Windows.Forms.CheckBox();
			newTreeView1 = new Xylia.Windows.Controls.TreeView();
			TextBox1 = new System.Windows.Forms.TextBox();
			MyAttributeVal = new System.Windows.Forms.TextBox();
			MyAttritube = new System.Windows.Forms.TextBox();
			TextBox2 = new System.Windows.Forms.TextBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			Level = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			ucWaveChart1 = new HZH_Controls.Controls.UCWaveChart();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)Level).BeginInit();
			SuspendLayout();
			// 
			// Btn_Start
			// 
			Btn_Start.Location = new System.Drawing.Point(694, 30);
			Btn_Start.Margin = new System.Windows.Forms.Padding(4);
			Btn_Start.Name = "Btn_Start";
			Btn_Start.Size = new System.Drawing.Size(88, 33);
			Btn_Start.TabIndex = 2;
			Btn_Start.Text = "计算";
			Btn_Start.Click += Btn_Start_Click;
			// 
			// AttritubeValue
			// 
			AttritubeValue.Location = new System.Drawing.Point(307, 35);
			AttritubeValue.Margin = new System.Windows.Forms.Padding(4);
			AttritubeValue.Name = "AttritubeValue";
			AttritubeValue.Size = new System.Drawing.Size(164, 23);
			AttritubeValue.TabIndex = 6;
			AttritubeValue.TextChanged += TextBox1_TextChanged;
			// 
			// numericUpDown1
			// 
			numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			numericUpDown1.DecimalPlaces = 3;
			numericUpDown1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			numericUpDown1.Location = new System.Drawing.Point(508, 82);
			numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(84, 23);
			numericUpDown1.TabIndex = 9;
			numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Label2
			// 
			Label2.AutoSize = true;
			Label2.Location = new System.Drawing.Point(307, 83);
			Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			Label2.Name = "Label2";
			Label2.Size = new System.Drawing.Size(164, 17);
			Label2.TabIndex = 10;
			Label2.Text = "额外的加成值（如暴伤八卦）";
			// 
			// Label3
			// 
			Label3.AutoSize = true;
			Label3.Location = new System.Drawing.Point(600, 85);
			Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			Label3.Name = "Label3";
			Label3.Size = new System.Drawing.Size(19, 17);
			Label3.TabIndex = 11;
			Label3.Text = "%";
			// 
			// AttritubeValue_Extra
			// 
			AttritubeValue_Extra.Location = new System.Drawing.Point(508, 35);
			AttritubeValue_Extra.Margin = new System.Windows.Forms.Padding(4);
			AttritubeValue_Extra.Name = "AttritubeValue_Extra";
			AttritubeValue_Extra.Size = new System.Drawing.Size(83, 23);
			AttritubeValue_Extra.TabIndex = 17;
			AttritubeValue_Extra.Text = "100";
			AttritubeValue_Extra.Visible = false;
			AttritubeValue_Extra.TextChanged += TextBox2_TextChanged;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { NewItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
			// 
			// NewItem
			// 
			NewItem.Name = "NewItem";
			NewItem.Size = new System.Drawing.Size(124, 22);
			NewItem.Text = "参数计算";
			NewItem.Click += NewItem_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			label1.Location = new System.Drawing.Point(310, 187);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(74, 21);
			label1.TabIndex = 19;
			label1.Text = "消息显示";
			// 
			// UseCompare
			// 
			UseCompare.AutoSize = true;
			UseCompare.Location = new System.Drawing.Point(508, 4);
			UseCompare.Margin = new System.Windows.Forms.Padding(4);
			UseCompare.Name = "UseCompare";
			UseCompare.Size = new System.Drawing.Size(75, 21);
			UseCompare.TabIndex = 20;
			UseCompare.Text = "追加对比";
			UseCompare.CheckedChanged += CheckBox1_CheckedChanged;
			// 
			// newTreeView1
			// 
			newTreeView1.BackColor = System.Drawing.Color.White;
			newTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			newTreeView1.ContextMenuStrip = contextMenuStrip1;
			newTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
			newTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
			newTreeView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			newTreeView1.HotTracking = true;
			newTreeView1.Indent = 20;
			newTreeView1.ItemHeight = 30;
			newTreeView1.Location = new System.Drawing.Point(0, 0);
			newTreeView1.Margin = new System.Windows.Forms.Padding(4);
			newTreeView1.Name = "newTreeView1";
			treeNode1.Name = "DefaultData";
			treeNode1.Text = "默认数据";
			newTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode1 });
			newTreeView1.ShowLines = false;
			newTreeView1.Size = new System.Drawing.Size(289, 459);
			newTreeView1.TabIndex = 18;
			newTreeView1.AfterSelect += newTreeView1_AfterSelect;
			// 
			// TextBox1
			// 
			TextBox1.Location = new System.Drawing.Point(270, 63);
			TextBox1.Name = "TextBox1";
			TextBox1.Size = new System.Drawing.Size(247, 23);
			TextBox1.TabIndex = 6;
			TextBox1.Text = "请输入对应的属性值";
			TextBox1.TextChanged += TextBox1_TextChanged;
			// 
			// MyAttributeVal
			// 
			MyAttributeVal.Location = new System.Drawing.Point(270, 63);
			MyAttributeVal.Name = "MyAttributeVal";
			MyAttributeVal.Size = new System.Drawing.Size(247, 23);
			MyAttributeVal.TabIndex = 6;
			MyAttributeVal.Text = "请输入对应的属性值";
			MyAttributeVal.TextChanged += TextBox1_TextChanged;
			// 
			// MyAttritube
			// 
			MyAttritube.Location = new System.Drawing.Point(270, 63);
			MyAttritube.Name = "MyAttritube";
			MyAttritube.Size = new System.Drawing.Size(247, 23);
			MyAttritube.TabIndex = 6;
			MyAttritube.Text = "请输入对应的属性值";
			MyAttritube.TextChanged += TextBox1_TextChanged;
			// 
			// TextBox2
			// 
			TextBox2.Location = new System.Drawing.Point(539, 63);
			TextBox2.Name = "TextBox2";
			TextBox2.Size = new System.Drawing.Size(95, 23);
			TextBox2.TabIndex = 17;
			TextBox2.Text = "100";
			TextBox2.Visible = false;
			TextBox2.TextChanged += TextBox2_TextChanged;
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new System.Drawing.Point(600, 35);
			pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(24, 24);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 21;
			pictureBox1.TabStop = false;
			pictureBox1.Visible = false;
			// 
			// Level
			// 
			Level.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			Level.Location = new System.Drawing.Point(508, 123);
			Level.Margin = new System.Windows.Forms.Padding(4);
			Level.Name = "Level";
			Level.Size = new System.Drawing.Size(83, 23);
			Level.TabIndex = 22;
			Level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			Level.Value = new decimal(new int[] { 60, 0, 0, 0 });
			Level.Visible = false;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(286, -68);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(116, 17);
			label4.TabIndex = 23;
			label4.Text = "请输入对应的属性值";
			// 
			// ucWaveChart1
			// 
			ucWaveChart1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			ucWaveChart1.ConerRadius = 10;
			ucWaveChart1.FillColor = System.Drawing.Color.FromArgb(50, 255, 77, 59);
			ucWaveChart1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			ucWaveChart1.GridLineColor = System.Drawing.Color.FromArgb(50, 255, 77, 59);
			ucWaveChart1.GridLineTextColor = System.Drawing.Color.FromArgb(150, 255, 77, 59);
			ucWaveChart1.IsRadius = true;
			ucWaveChart1.IsShowRect = false;
			ucWaveChart1.LineColor = System.Drawing.Color.FromArgb(150, 255, 77, 59);
			ucWaveChart1.LineTension = 0.5F;
			ucWaveChart1.Location = new System.Drawing.Point(310, 228);
			ucWaveChart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			ucWaveChart1.Name = "ucWaveChart1";
			ucWaveChart1.RectColor = System.Drawing.Color.FromArgb(232, 232, 232);
			ucWaveChart1.RectWidth = 1;
			ucWaveChart1.Size = new System.Drawing.Size(428, 205);
			ucWaveChart1.SleepTime = 500;
			ucWaveChart1.TabIndex = 24;
			ucWaveChart1.Visible = false;
			ucWaveChart1.WaveWidth = 50;
			// 
			// MainFrm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(ucWaveChart1);
			Controls.Add(label4);
			Controls.Add(Level);
			Controls.Add(pictureBox1);
			Controls.Add(UseCompare);
			Controls.Add(label1);
			Controls.Add(newTreeView1);
			Controls.Add(AttritubeValue_Extra);
			Controls.Add(Label3);
			Controls.Add(numericUpDown1);
			Controls.Add(AttritubeValue);
			Controls.Add(Btn_Start);
			Controls.Add(Label2);
			Margin = new System.Windows.Forms.Padding(4);
			Name = "MainFrm";
			Size = new System.Drawing.Size(803, 459);
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)Level).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private System.Windows.Forms.Button Btn_Start;
		private System.Windows.Forms.TextBox AttritubeValue;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label3;
		private System.Windows.Forms.TextBox AttritubeValue_Extra;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		protected Xylia.Windows.Controls.TreeView newTreeView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox UseCompare;
		private System.Windows.Forms.ToolStripMenuItem NewItem;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.TextBox MyAttributeVal;
		private System.Windows.Forms.TextBox MyAttritube;
		private System.Windows.Forms.TextBox TextBox2;
		private System.Windows.Forms.NumericUpDown Level;
		private System.Windows.Forms.Label label4;
		private HZH_Controls.Controls.UCWaveChart ucWaveChart1;
	}
}