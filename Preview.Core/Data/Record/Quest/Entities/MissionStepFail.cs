using Xylia.Attribute.Component;


namespace Xylia.Preview.Data.Record.QuestData
{
	[Signal("mission-step-fail")]
	public sealed class MissionStepFail : CaseParent
	{
		[Signal("rollback-step-id")]
		public byte RollbackStepID;

		/// <summary>
		/// 直接放弃任务
		/// </summary>
		[Signal("dispose-quest")]
		public bool DisposeQuest;

		public byte Step;


		[Side(Side.Type.Client)]
		[Signal("fail-talksocial")]
		public TalkSocial FailTalksocial;

		[Side(Side.Type.Client)]
		[Signal("fail-talksocial-delay")]
		public float FailTalksocialDelay;





		[Side(Side.Type.Server)]
		[Signal("quest-decision")]
		public string QuestDecision;

		[Side(Side.Type.Server)] 
		[Signal("zone-1")] 
		public string Zone1;

		[Side(Side.Type.Server)] 
		[Signal("zone-2")] 
		public string Zone2;
	}
}