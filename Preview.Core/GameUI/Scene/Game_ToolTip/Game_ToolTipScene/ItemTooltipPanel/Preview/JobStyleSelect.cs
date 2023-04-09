﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Package.Pak;

namespace Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel.Preview
{
	[DesignTimeVisible(false)]
	public partial class JobStyleSelect : UserControl
	{
		public JobStyleSelect() => InitializeComponent();

		#region 委托 
		public delegate void JobStyleChangedHandle(JobStyleSeq JobStyle);

		public event JobStyleChangedHandle JobStyleChanged;
		#endregion

		#region Functions
		/// <summary>
		/// Load 派系图标
		/// </summary>
		/// <param name="job"></param>
		public void LoadStyleIcon(JobSeq job)
		{
			if (job == JobSeq.JobNone) return;

			foreach (var o in FileCache.Data.JobStyle.Where(o => o.Job == job))
			{
				var icon = o.IntroduceJobStyleIcon.GetUObject().GetImage();
				if (icon is null) continue;

				switch (o.jobStyle)
				{
					case JobStyleSeq.Advanced1: SetImage(this.JobStyle6, icon); break;
					case JobStyleSeq.Advanced2: SetImage(this.JobStyle7, icon); break;
					case JobStyleSeq.Advanced3: SetImage(this.JobStyle8, icon); break;
					case JobStyleSeq.Advanced4: SetImage(this.JobStyle9, icon); break;
					case JobStyleSeq.Advanced5: SetImage(this.JobStyle10, icon); break;
				}
			}
		}

		private void SetImage(PictureBox pictureBox, Bitmap bitmap)
		{
			pictureBox.Image = bitmap;
			pictureBox.Visible = true;
		}



		public void SelectDefault() => JobStyleChanged?.Invoke(JobStyleSeq.Advanced1);

		private void JobStyle6_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(JobStyleSeq.Advanced1);
		private void JobStyle7_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(JobStyleSeq.Advanced2);
		private void JobStyle8_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(JobStyleSeq.Advanced3);
		private void JobStyle9_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(JobStyleSeq.Advanced4);
		private void JobStyle10_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(JobStyleSeq.Advanced5);
		#endregion
	}
}