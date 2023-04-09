using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls;
using Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel.Cell;

namespace Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel
{
	[DesignTimeVisible(true)]
	public partial class SkillByEquipmentTooltip : TitlePanel
	{
		#region Constructor
		public SkillByEquipmentTooltip()
		{
			InitializeComponent();
		}
		#endregion


		#region Interface Functions
		public override void LoadData(BaseRecord record)
		{
			var Record = record as SkillByEquipment;

			List<SkillModifyCell> cells = new();
			void CreateCell(int Skill3ID, Text Tooltip, out Skill3 Skill)
			{
				Skill = FileCache.Data.Skill3[Skill3ID, 1];
				if (Skill is null) return;

				cells.Add(new SkillModifyCell()
				{
					SkillName = Skill.Name2.GetText(),
					TooltipText = Tooltip.GetText(),
				});
			}

			CreateCell(Record.Skill3Id1, Record.TooltipText1, out var Skill);
			CreateCell(Record.Skill3Id2, Record.TooltipText2, out _);
			CreateCell(Record.Skill3Id3, Record.TooltipText3, out _);
			CreateCell(Record.Skill3Id4, Record.TooltipText4, out _);





			this.Controls.Remove<SkillModifyCell>();

			//设置文本起始位置
			const int StartY = 25;
			int LocY = StartY;
			foreach (var SkillModifyCell in cells)
			{
				SkillModifyCell.Location = new Point(100, LocY);
				this.Controls.Add(SkillModifyCell);

				LocY = SkillModifyCell.Bottom + 1;
			}

			this.Height = LocY;

			//计算技能图标位置	   
			this.SkillIcon.Image = Skill?.MainIcon();
			this.SkillIcon.Location = new Point(this.SkillIcon.Location.X, (StartY + LocY - this.SkillIcon.Height) / 2);
		}
		#endregion
	}
}