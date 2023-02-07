
using Xylia.Attribute.Component;


namespace Xylia.Preview.Data.Record
{
	public sealed class ItemBrand : BaseRecord
	{
		#region 属性字段
		[Signal("ui-item-transform")]
		public string UiItemTransform;

		[Signal("ui-item-blade-master")]
		public string UiItemBladeMaster;

		[Signal("ui-item-kung-fu-fighter")]
		public string UiItemKungFuFighter;

		[Signal("ui-item-force-master")]
		public string UiItemForceMaster;

		[Signal("ui-item-shooter")]
		public string UiItemShooter;

		[Signal("ui-item-destroyer")]
		public string UiItemDestroyer;

		[Signal("ui-item-summoner")]
		public string UiItemSummoner;

		[Signal("ui-item-assassin")]
		public string UiItemAssassin;

		[Signal("ui-item-sword-master")]
		public string UiItemSwordMaster;

		[Signal("ui-item-warlock")]
		public string UiItemWarlock;

		[Signal("ui-item-soul-fighter")]
		public string UiItemSoulFighter;

		[Signal("ui-item-warrior")]
		public string UiItemWarrior;

		[Signal("ui-item-archer")]
		public string UiItemArcher;

		[Signal("ui-item-spear")]
		public string UiItemSpear;

		[Signal("ui-item-thunderer")]
		public string UiItemThunderer;

		[Signal("ui-item-dual-sword")]
		public string UiItemDualSword;
		#endregion
	}
}