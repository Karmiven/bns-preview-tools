﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Xylia.Extension;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Record;
using Xylia.Preview.GameUI.Controls;
using Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel.Cell;

namespace Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel
{
	public partial class SlateScrollTooltip : TitlePanel
	{
		#region Constructor
		public SlateScrollTooltip() => InitializeComponent();
		#endregion

		#region Functions
		private void SlateScrollTooltip_SizeChanged(object sender, EventArgs e)
		{
			foreach (var Cell in this.Controls.OfType<SlateScrollCell>())
			{
				Cell.Width = this.Width - 12;
			}
		}
		#endregion


		#region Interface Functions
		public override void LoadData(BaseRecord record)
		{
			#region 筛选出刻印书与血石的对应信息
			//执行排序：将推荐血石排序到前面, 同时抽取部分非推荐血石
			//然后取出前N个对象, 不足时则不执行
			var ScrollStones = FileCache.Data.SlateScrollStone.Where(info => info.scroll == record).ToList();
			ScrollStones.Sort(new SlateScrollStoneSort() { SortByGrade = false });

			if (ScrollStones.Count > 20) ScrollStones = ScrollStones.Take(20).ToList();
			ScrollStones.Sort(new SlateScrollStoneSort() { SortByGrade = true });
			#endregion

			#region 处理血石信息并生成控件
			var cells = new List<SlateScrollCell>();
			foreach (var Stone in ScrollStones.Select(s => FileCache.Data.SlateStone[s.stone]))
			{
				#region get attr
				char SplitChar = '，';   //设置分隔符号
				string AbilityInfo = null;

				void GetAbility(AttachAbility ability, int max_ability_value)
				{
					if (ability == 0) return;
					AbilityInfo += ability.GetName(max_ability_value)  + SplitChar;
				}

				GetAbility(Stone.ModifyAbility1, Stone.MaxAbilityValue1);
				GetAbility(Stone.ModifyAbility2, Stone.MaxAbilityValue2);
				GetAbility(Stone.ModifyAbility3, Stone.MaxAbilityValue3);
				GetAbility(Stone.ModifyAbility4, Stone.MaxAbilityValue4);

				AbilityInfo = AbilityInfo?.RemoveSuffixString(SplitChar);
				#endregion

				cells.Add(new SlateScrollCell()
				{
					Icon = Stone.Icon.GetIcon(),
					Text = Stone.Name.GetText(),
					Grade = Stone.Grade,

					AbilityInfo = AbilityInfo,
				});
			}
			#endregion

			#region UI
			int LoY = 21 + 8;
			foreach (var Cell in cells)
			{
				Cell.Location = new Point(0, LoY - 8);
				Cell.Width = this.Width - 12;
				this.Controls.Add(Cell);

				Cell.BringToFront();
				LoY = Cell.Bottom;
			}

			//渲染底部提示
			this.Guide.BringToFront();
			this.Guide.Location = new Point(this.Guide.Location.X, LoY);

			this.Height = this.Guide.Bottom;
			#endregion
		}
		#endregion
	}



	public class SlateScrollStoneSort : IComparer<SlateScrollStone>
	{
		/// <summary>
		/// 按品级排序
		/// </summary>
		public bool SortByGrade = false;

		public int Compare(SlateScrollStone x, SlateScrollStone y)
		{
			if (x is null || y is null) return 0;

			if (SortByGrade)
			{
				var Grade1 = FileCache.Data.SlateStone[x.stone]?.Grade ?? 0;
				var Grade2 = FileCache.Data.SlateStone[y.stone]?.Grade ?? 0;

				return Grade2 - Grade1;
			}

			if (x.recommend && y.recommend) return x.Key() - y.Key();
			else if (!x.recommend && y.recommend) return 1;
			else if (x.recommend && !y.recommend) return -1;

			//随机排序非推荐血石	  
			return Execute.RandomStream[0].Next(-1, 2);
		}
	}
}
