using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xylia.Preview.Common.Attribute;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Record.QuestData.Enums;

namespace Xylia.Preview.Data.Record.QuestData
{
	[Signal("case")]
	public abstract class CaseBase : TypeBaseRecord<CaseType>
	{
		[Signal("filter-set")]
		public List<FilterSet> FilterSet;



		[DefaultValue(100)]
		public byte Prob = 100;

		[Side(Side.Type.Client)][Signal("mapunit-1")] public string MapUnit1;
		[Side(Side.Type.Client)][Signal("mapunit-2")] public string MapUnit2;
		[Side(Side.Type.Client)][Signal("mapunit-3")] public string MapUnit3;
		[Side(Side.Type.Client)][Signal("mapunit-4")] public string MapUnit4;
		[Side(Side.Type.Client)][Signal("mapunit-5")] public string MapUnit5;
		[Side(Side.Type.Client)][Signal("mapunit-6")] public string MapUnit6;
		[Side(Side.Type.Client)][Signal("mapunit-7")] public string MapUnit7;
		[Side(Side.Type.Client)][Signal("mapunit-8")] public string MapUnit8;
		[Side(Side.Type.Client)][Signal("mapunit-9")] public string MapUnit9;
		[Side(Side.Type.Client)][Signal("mapunit-10")] public string MapUnit10;

		[DefaultValue(-1)]
		[Signal("range-max")]
		public short RangeMax = -1;

		[DefaultValue(-1)]
		[Signal("range-min")]
		public short RangeMin = -1;

		[Signal("progress-mission")]
		public ProgressMission ProgressMission = ProgressMission.N;

		[Signal("progress-value")]
		public int ProgressValue;

		/// <summary>
		/// 可获取任务
		/// </summary>
		[Signal("acquire-quest")]
		public bool AcquireQuest;

		[Signal("gadget-required")]
		public GadgetRequired GadgetRequired;

		public FieldItem Gadget;

		[Side(Side.Type.Client)]
		[Signal("unload-map-navigation-object")]
		public string UnloadMapNavigationObject;

		[Signal("valid-zone-1")]
		public Zone ValidZone1;

		[Signal("valid-zone-2")]
		public Zone ValidZone2;

		[Signal("completion-count")]
		public byte CompletionCount;

		[Signal("completion-count-op")]
		public Op CompletionCountOp = Op.ge;

		[Side(Side.Type.Client)]
		public Indicator Indicator;

		[Side(Side.Type.Client)]
		[Signal("show-in-tooltip")]
		public bool ShowInTooltip;

		[Side(Side.Type.Client)]
		[Signal("visible-object")]
		public bool VisibleObject;

		[Obsolete]
		[Side(Side.Type.Client)]
		[Signal("case-talksocial")]
		public TalkSocial CaseTalksocial;

		[Side(Side.Type.Client)]
		[Signal("case-talksocial-delay")]
		public float CaseTalksocialDelay;







		// 旧版本物品消耗
		[Obsolete][Signal("grocery")] 
		public string Grocery;

		[Obsolete][Signal("grocery-count")]
		public short GroceryCount = 1;

		[Obsolete][Signal("remove-grocery")] 
		public bool RemoveGrocery;

		// 新版本物品消耗
		[Signal("required-money")]
		public int RequiredMoney;

		[Signal("required-item-depot")]
		public DepotType RequiredItemDepot;

		[Signal("required-item-1")]
		public Item RequiredItem1;

		[Signal("required-item-2")]
		public Item RequiredItem2;

		[Signal("required-item-3")]
		public Item RequiredItem3;

		[Signal("required-item-4")]
		public Item RequiredItem4;

		[Signal("required-item-count-1")]
		public short RequiredItemCount1;

		[Signal("required-item-count-2")]
		public short RequiredItemCount2;

		[Signal("required-item-count-3")]
		public short RequiredItemCount3;

		[Signal("required-item-count-4")]
		public short RequiredItemCount4;

		[Signal("required-item-loss")]
		public bool RequiredItemLoss;

		[Signal("required-item-brand-1")]
		public ItemBrand RequiredItemBrand1;

		[Signal("required-item-brand-2")]
		public ItemBrand RequiredItemBrand2;

		[Signal("required-equip-gem-set")]
		public SetItem RequiredEquipGemSet;




		//public string Object;

		//public string Object2;

		
		[Signal("faction-killed-count-min")]
		public byte FactionKilledCountMin;

		[Signal("faction-killed-count-max")]
		public byte FactionKilledCountMax;




		[Side(Side.Type.Server)]
		public string Zone;

		[Side(Side.Type.Server)]
		[Signal("quest-decision")]
		public string QuestDecision;

		[Side(Side.Type.Server)]
		[Signal("fail-quest-decision")]
		public string FailQuestDecision;

		/// <summary>
		/// 掉落物品
		/// </summary>
		[Side(Side.Type.Server)]
		[Signal("drop-gadget")]
		public string DropGadget;

		[Side(Side.Type.Server)]
		[Signal("party-broadcast")]
		public bool PartyBroadcast = false;

		[Side(Side.Type.Server)]
		[Signal("team-broadcast")]
		public bool TeamBroadcast = false;



		//去重后返回 .Distinct().ToList()
		public virtual List<string> AttractionObject => new() { /*Object, Object2*/ };
	}
}