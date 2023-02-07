using Xylia.Attribute.Component;

using Xylia.bns.Modules.AIData.Script.Decision;

namespace Xylia.bns.Modules.AIData.Script.Entities.Decision
{
	[Signal("quest-decision")]
	public sealed class QuestDecision : IDecision
	{
		#region 字段
		public string Alias;


		//recation  mission-step-completed 	mission-step-skipped  mission-step-failed	 
		#endregion
	}
}
