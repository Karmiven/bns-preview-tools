using Xylia.Attribute.Component;

using Xylia.bns.Modules.AIData.CombatSequence.Action.Base;
using  Xylia.Preview.Data.Record;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	[Signal("boss-multiground-attack")]
	public sealed class BossMultigroundAttack : SkillBase
	{
		#region 字段
		[Signal("ground-pattern-1")] 
		public BossGroundAttackTargetPattern GroundPattern1;

		[Signal("ground-pattern-2")] 
		public BossGroundAttackTargetPattern GroundPattern2;

		[Signal("ground-pattern-3")] 
		public BossGroundAttackTargetPattern GroundPattern3;

		[Signal("ground-pattern-4")] 
		public BossGroundAttackTargetPattern GroundPattern4;

		[Signal("ground-pattern-5")] 
		public BossGroundAttackTargetPattern GroundPattern5;

		[Signal("origin-pos")] 
		public string OriginPos;
		#endregion
	}
}