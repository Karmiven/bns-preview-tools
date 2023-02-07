namespace Xylia.Match.Windows.Panel
{
    partial class Youdao
	{
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.Btn_Start = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Copy = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Open = new System.Windows.Forms.OpenFileDialog();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.Copy2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 13);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(447, 23);
			this.textBox1.TabIndex = 0;
			this.textBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextBox1_MouseDoubleClick);
			// 
			// Btn_Start
			// 
			this.Btn_Start.Location = new System.Drawing.Point(617, 13);
			this.Btn_Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Btn_Start.Name = "Btn_Start";
			this.Btn_Start.Size = new System.Drawing.Size(88, 33);
			this.Btn_Start.TabIndex = 1;
			this.Btn_Start.Text = "转换";
			this.Btn_Start.UseVisualStyleBackColor = true;
			this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(120, 64);
			this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(447, 23);
			this.textBox3.TabIndex = 3;
			this.textBox3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextBox3_MouseDoubleClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 68);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "直链";
			// 
			// Copy
			// 
			this.Copy.Location = new System.Drawing.Point(617, 74);
			this.Copy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Copy.Name = "Copy";
			this.Copy.Size = new System.Drawing.Size(88, 33);
			this.Copy.TabIndex = 9;
			this.Copy.Text = "复制";
			this.Copy.UseVisualStyleBackColor = true;
			this.Copy.Click += new System.EventHandler(this.Button1_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 177);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "文件信息";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 17);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 17);
			this.label1.TabIndex = 11;
			this.label1.Text = "有道云分享链接";
			// 
			// Open
			// 
			this.Open.CheckFileExists = false;
			this.Open.CheckPathExists = false;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(12, 129);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(75, 21);
			this.checkBox1.TabIndex = 15;
			this.checkBox1.Text = "结果拆分";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(120, 123);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(447, 23);
			this.textBox2.TabIndex = 16;
			// 
			// Copy2
			// 
			this.Copy2.Location = new System.Drawing.Point(617, 123);
			this.Copy2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Copy2.Name = "Copy2";
			this.Copy2.Size = new System.Drawing.Size(88, 33);
			this.Copy2.TabIndex = 17;
			this.Copy2.Text = "复制";
			this.Copy2.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Copy2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Copy);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.Btn_Start);
			this.Controls.Add(this.textBox1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "Form1";
			this.Size = new System.Drawing.Size(838, 424);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Copy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog Open;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Copy2;
    }
}

