using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Record.QuestData.Case;
using Xylia.Preview.Data.Record.QuestData.TutorialCase;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.QuestData
{
	/// <summary>
	/// Case类型的母对象
	/// </summary>
	public abstract class CaseParent : BaseNode
	{
		[FStruct(StructType.Meta)]
		public List<BaseNode> Cases = new();

		[FStruct(StructType.Meta)]
		public List<BasicReward> BasicRewards = new();

		[FStruct(StructType.Meta)]
		public List<FixedReward> FixedRewards = new();

		[FStruct(StructType.Meta)]
		public List<OptionalReward> OptionalRewards = new();

		[FStruct(StructType.Meta)]
		public List<AcquisitionLoss> AcquisitionLosses = new();

		[FStruct(StructType.Meta)]
		public List<CompletionLoss> CompletionLosses = new();



		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);

			var nodeList = xe.SelectNodes("./case|./tutorial-case");
			for (int idx = 0; idx < nodeList.Count; idx++)
			{
				BaseNode CaseEntity = null;
				var CaseNode = (XmlElement)nodeList[idx];
				if (CaseNode.Name == "case")
				{
					CaseEntity = CaseNode.TypeFactory<CaseType, CaseBase>(idx, this, (s) => s switch
					{
						CaseType.AcquireSummoned => new AcquireSummoned(),
						CaseType.Approach => new Approach(),
						CaseType.AttractionPopup => new AttractionPopup(),
						CaseType.BattleRoyal => new BattleRoyal(),
						CaseType.CompleteQuest => new CompleteQuest(),
						CaseType.ConvoyArrived => new ConvoyArrived(),
						CaseType.ConvoyFailed => new ConvoyFailed(),
						CaseType.DuelFinish => new DuelFinish(),
						CaseType.EnterPortal => new EnterPortal(),
						CaseType.EnterZone => new EnterZone(),
						CaseType.EnvEntered => new EnvEntered(),
						CaseType.JoinFaction => new JoinFaction(),
						CaseType.Killed => new Killed(),
						CaseType.Loot => new Loot(),
						CaseType.Manipulate => new Manipulate(),
						CaseType.NpcBleedingOccured => new NpcBleedingOccured(),
						CaseType.NpcManipulate => new NpcManipulate(),
						CaseType.PartyBattle => new PartyBattle(),
						CaseType.PartyBattleAction => new PartyBattleAction(),
						CaseType.PcSocial => new PcSocial(),
						CaseType.PickUpFielditem => new Case.PickUpFielditem(),
						CaseType.PublicRaid => new Case.PublicRaid(),
						CaseType.Skill => new Case.Skill(),
						CaseType.Talk => new Talk(),
						CaseType.TalkToItem => new TalkToItem(),
						CaseType.TalkToSelf => new TalkToSelf(),

						_ => null
					});
				}
				else if (CaseNode.Name == "tutorial-case")
				{
					CaseEntity = CaseNode.TypeFactory<TutorialCaseType, TutorialCaseBase>(idx, this, (s) => s switch
					{
						TutorialCaseType.AcquireItem => new AcquireItem(),
						TutorialCaseType.AcquireSp => new AcquireSp(),
						TutorialCaseType.Airdash => new Airdash(),
						TutorialCaseType.Attacked => new Attacked(),
						TutorialCaseType.ChargeHeartCount => new ChargeHeartCount(),
						TutorialCaseType.CompleteSelfRevival => new CompleteSelfRevival(),
						TutorialCaseType.DetachWeaponGem => new DetachWeaponGem(),
						TutorialCaseType.EnlargeMiniMap => new EnlargeMiniMap(),
						TutorialCaseType.TransparentMiniMap => new TransparentMiniMap(),
						TutorialCaseType.EquipItem => new EquipItem(),
						TutorialCaseType.Exhausted => new Exhausted(),
						TutorialCaseType.ExpandInventory => new ExpandInventory(),
						TutorialCaseType.GemCompose => new GemCompose(),
						TutorialCaseType.GemDecompose => new GemDecompose(),
						TutorialCaseType.GrowItem => new GrowItem(),
						TutorialCaseType.MoveToPosition => new MoveToPosition(),
						TutorialCaseType.NpcBleeding => new NpcBleeding(),
						TutorialCaseType.PcBleeding => new PcBleeding(),
						TutorialCaseType.PickDownFielditem => new PickDownFielditem(),
						TutorialCaseType.PickUpFielditem => new TutorialCase.PickUpFielditem(),
						TutorialCaseType.QuestTrackingPosition => new QuestTrackingPosition(),
						TutorialCaseType.RepairWithCampfire => new RepairWithCampfire(),
						TutorialCaseType.ResurrectingSummoned => new ResurrectingSummoned(),
						TutorialCaseType.Skill => new TutorialCase.Skill(),
						TutorialCaseType.SkillSequence => new SkillSequence(),
						TutorialCaseType.SkillTraining => new SkillTraining(),
						TutorialCaseType.TalkStart => new TalkStart(),
						TutorialCaseType.Targeting => new Targeting(),
						TutorialCaseType.Teleport => new TutorialCase.Teleport(),
						TutorialCaseType.TeleportZone => new TeleportZone(),
						TutorialCaseType.TransformItem => new TransformItem(),
						TutorialCaseType.UseHeartCount => new UseHeartCount(),
						TutorialCaseType.UseItem => new UseItem(),
						TutorialCaseType.WeaponGem => new WeaponGem(),
						TutorialCaseType.WindowOpen => new WindowOpen(),

						_ => null
					});
				}

				Cases.Add(CaseEntity);
			}

			this.AcquisitionLosses = BaseNode.LoadChildren<AcquisitionLoss>(xe, "acquisition-loss");
			this.CompletionLosses = BaseNode.LoadChildren<CompletionLoss>(xe, "completion-loss");
			this.BasicRewards = BaseNode.LoadChildren<BasicReward>(xe, "basic-reward");
			this.FixedRewards = BaseNode.LoadChildren<FixedReward>(xe, "fixed-reward");
			this.OptionalRewards = BaseNode.LoadChildren<OptionalReward>(xe, "optional-reward");
		}
		#endregion
	}
}