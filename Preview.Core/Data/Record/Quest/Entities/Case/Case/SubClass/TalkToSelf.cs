using System;

using Xylia.Preview.Common.Attribute;
using Xylia.Preview.Common.Seq;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class TalkToSelf : CaseBase
	{
		/// <summary>
		/// 免费接收 (功能已废弃)
		/// </summary>
		[Obsolete]
		public bool Fee;

		[Side(Side.Type.Client)]
		public VirtualItem Item;

		[Side(Side.Type.Client)]
		public NpcTalkMessage Msg;



		[Signal("check-inventory-full")]
		public bool CheckInventoryFull;

		[Signal("check-equiped-durability-below")]
		public byte CheckEquipedDurabilityBelow;

		[Signal("check-exp-boost-normal-below")]
		public byte CheckExpBoostNormalBelow;

		[Signal("required-jumping-character-state")]
		public JumpingCharacterState RequiredJumpingCharacterState;
	}
}