using Xylia.Attribute.Component;

using static Xylia.Preview.Data.Record.QuestData.Case.DuelFinish;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public abstract class NpcTalkBase : CaseBase
	{
		public string Object;

		public string Object2;


		[Side(Side.Type.Client)]
		[Signal("npc-response")]
		public NpcResponse NpcResponse;

		[Side(Side.Type.Client)]
		public NpcTalkMessage Msg;

		[Side(Side.Type.Client)]
		[Signal("start-msg")]
		public NpcTalkMessage StartMsg;

		[Side(Side.Type.Client)]
		[Signal("indicator-social")]
		public IndicatorSocial IndicatorSocial;

		[Side(Side.Type.Client)]
		[Signal("indicator-idle")]
		public IndicatorIdle IndicatorIdle;

		[Side(Side.Type.Client)]
		[Signal("button-text-accept")]
		public string ButtonTextAccept;

		[Side(Side.Type.Client)]
		[Signal("button-text-cancel")]
		public string ButtonTextCancel;




		[Signal("faction-killed-count-min")]
		public byte FactonKilledCountMin;

		[Signal("faction-killed-count-max")]
		public byte FactonKilledCountMax;

		[Signal("duel-type")]
		public DuelTypeSeq DuelType;

		[Signal("arena-matching-rule-detail")]
		public ArenaMatchingRule ArenaMatchingRuleDetail;

		[Signal("duel-straight-win")]
		public int DuelStraightWin;
	}
}