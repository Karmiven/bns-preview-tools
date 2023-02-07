using Xylia.Attribute.Component;
using Xylia.Preview.Common.Seq;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class WindowOpen : TutorialCaseBase
	{
		#region 字段
		[Signal("window-type")]
		[Side(Side.Type.Client)]
		public WindowTypeSeq WindowType;

		public enum WindowTypeSeq
		{
			Inverntory,

			[Signal("quest-journal")]
			QuestJournal,

			Skill,

			Sandbox,

			Auction,

			[Signal("cash-shop")]
			CashShop,

			Wardrobe,

			[Signal("account-contents")]
			AccountContents,
		}



		[Signal("window-open-way")]
		[Side(Side.Type.Client)]
		public WindowOpenWaySeq WindowOpenWay;

		public enum WindowOpenWaySeq
		{
			None,

			[Signal("by-npc-seller-button")]
			ByNpcSellerButton,
		}
		#endregion
	}
}