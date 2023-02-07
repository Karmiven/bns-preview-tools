using System;

namespace Xylia.Preview.GameUI.Scene.Game_ToolTip.ItemTooltipPanel.Preview.Reward
{
	/// <summary>
	/// 选择奖励事件
	/// </summary>
	public class RewardChangedEvent : EventArgs
	{
		public RewardChangedEvent(RewardPage RewardPage) => this.Page = RewardPage;


		public RewardPage Page;
	}
}