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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("默认数据");
			this.Btn_Start = new System.Windows.Forms.Button();
			this.AttritubeValue = new System.Windows.Forms.TextBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.AttritubeValue_Extra = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.NewItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.UseCompare = new System.Windows.Forms.CheckBox();
			this.newTreeView1 = new Xylia.Windows.Controls.TreeView();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.MyAttributeVal = new System.Windows.Forms.TextBox();
			this.MyAttritube = new System.Windows.Forms.TextBox();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.Level = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Level)).BeginInit();
			this.SuspendLayout();
			// 
			// Btn_Start
			// 
			this.Btn_Start.Location = new System.Drawing.Point(694, 30);
			this.Btn_Start.Margin = new System.Windows.Forms.Padding(4);
			this.Btn_Start.Name = "Btn_Start";
			this.Btn_Start.Size = new System.Drawing.Size(88, 33);
			this.Btn_Start.TabIndex = 2;
			this.Btn_Start.Text = "计算";
			this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
			// 
			// AttritubeValue
			// 
			this.AttritubeValue.Location = new System.Drawing.Point(307, 35);
			this.AttritubeValue.Margin = new System.Windows.Forms.Padding(4);
			this.AttritubeValue.Name = "AttritubeValue";
			this.AttritubeValue.Size = new System.Drawing.Size(164, 23);
			this.AttritubeValue.TabIndex = 6;
			this.AttritubeValue.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numericUpDown1.DecimalPlaces = 3;
			this.numericUpDown1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.numericUpDown1.Location = new System.Drawing.Point(508, 82);
			this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(84, 23);
			this.numericUpDown1.TabIndex = 9;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(307, 83);
			this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(164, 17);
			this.Label2.TabIndex = 10;
			this.Label2.Text = "额外的加成值（如暴伤八卦）";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(600, 85);
			this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(19, 17);
			this.Label3.TabIndex = 11;
			this.Label3.Text = "%";
			// 
			// AttritubeValue_Extra
			// 
			this.AttritubeValue_Extra.Location = new System.Drawing.Point(508, 35);
			this.AttritubeValue_Extra.Margin = new System.Windows.Forms.Padding(4);
			this.AttritubeValue_Extra.Name = "AttritubeValue_Extra";
			this.AttritubeValue_Extra.Size = new System.Drawing.Size(83, 23);
			this.AttritubeValue_Extra.TabIndex = 17;
			this.AttritubeValue_Extra.Text = "100";
			this.AttritubeValue_Extra.Visible = false;
			this.AttritubeValue_Extra.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
			// 
			// NewItem
			// 
			this.NewItem.Name = "NewItem";
			this.NewItem.Size = new System.Drawing.Size(124, 22);
			this.NewItem.Text = "参数计算";
			this.NewItem.Click += new System.EventHandler(this.NewItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(310, 187);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 21);
			this.label1.TabIndex = 19;
			this.label1.Text = "消息显示";
			// 
			// UseCompare
			// 
			this.UseCompare.AutoSize = true;
			this.UseCompare.Location = new System.Drawing.Point(508, 4);
			this.UseCompare.Margin = new System.Windows.Forms.Padding(4);
			this.UseCompare.Name = "UseCompare";
			this.UseCompare.Size = new System.Drawing.Size(75, 21);
			this.UseCompare.TabIndex = 20;
			this.UseCompare.Text = "追加对比";
			this.UseCompare.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
			// 
			// newTreeView1
			// 
			this.newTreeView1.BackColor = System.Drawing.Color.White;
			this.newTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.newTreeView1.ContextMenuStrip = this.contextMenuStrip1;
			this.newTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.newTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
			this.newTreeView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.newTreeView1.HotTracking = true;
			this.newTreeView1.Indent = 20;
			this.newTreeView1.ItemHeight = 30;
			this.newTreeView1.Location = new System.Drawing.Point(0, 0);
			this.newTreeView1.Margin = new System.Windows.Forms.Padding(4);
			this.newTreeView1.Name = "newTreeView1";
			treeNode1.Name = "DefaultData";
			treeNode1.Text = "默认数据";
			this.newTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
			this.newTreeView1.ShowLines = false;
			this.newTreeView1.Size = new System.Drawing.Size(289, 459);
			this.newTreeView1.TabIndex = 18;
			this.newTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.newTreeView1_AfterSelect);
			// 
			// TextBox1
			// 
			this.TextBox1.Location = new System.Drawing.Point(270, 63);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(247, 23);
			this.TextBox1.TabIndex = 6;
			this.TextBox1.Text = "请输入对应的属性值";
			this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			// 
			// MyAttributeVal
			// 
			this.MyAttributeVal.Location = new System.Drawing.Point(270, 63);
			this.MyAttributeVal.Name = "MyAttributeVal";
			this.MyAttributeVal.Size = new System.Drawing.Size(247, 23);
			this.MyAttributeVal.TabIndex = 6;
			this.MyAttributeVal.Text = "请输入对应的属性值";
			this.MyAttributeVal.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			// 
			// MyAttritube
			// 
			this.MyAttritube.Location = new System.Drawing.Point(270, 63);
			this.MyAttritube.Name = "MyAttritube";
			this.MyAttritube.Size = new System.Drawing.Size(247, 23);
			this.MyAttritube.TabIndex = 6;
			this.MyAttritube.Text = "请输入对应的属性值";
			this.MyAttritube.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			// 
			// TextBox2
			// 
			this.TextBox2.Location = new System.Drawing.Point(539, 63);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(95, 23);
			this.TextBox2.TabIndex = 17;
			this.TextBox2.Text = "100";
			this.TextBox2.Visible = false;
			this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(600, 35);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 24);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 21;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// Level
			// 
			this.Level.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Level.Location = new System.Drawing.Point(508, 123);
			this.Level.Margin = new System.Windows.Forms.Padding(4);
			this.Level.Name = "Level";
			this.Level.Size = new System.Drawing.Size(83, 23);
			this.Level.TabIndex = 22;
			this.Level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Level.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.Level.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(286, -68);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 17);
			this.label4.TabIndex = 23;
			this.label4.Text = "请输入对应的属性值";
			// 
			// MainFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Level);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.UseCompare);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.newTreeView1);
			this.Controls.Add(this.AttritubeValue_Extra);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.AttritubeValue);
			this.Controls.Add(this.Btn_Start);
			this.Controls.Add(this.Label2);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainFrm";
			this.Size = new System.Drawing.Size(803, 459);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Level)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

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
	}
}