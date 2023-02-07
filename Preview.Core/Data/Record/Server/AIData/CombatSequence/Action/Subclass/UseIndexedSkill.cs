using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	[Signal("use-indexed-skill")]
	public sealed class UseIndexedSkill : IAction
	{
		#region 字段
		public int Skill;

		public int Skill3;
		#endregion
	}
}