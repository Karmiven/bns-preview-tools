using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	[Signal("boss-sp-select-attack")]
	public sealed class BossSpSelectAttack : IAction
	{
		#region 字段
		[Signal("sp-1")] public byte Sp1;
		[Signal("sp-2")] public byte Sp2;
		[Signal("sp-3")] public byte Sp3;

		[Signal("skill-1")] public string Skill1;
		[Signal("skill-2")] public string Skill2;
		[Signal("skill-3")] public string Skill3;

		[Signal("skill3-1")] public string Skill3_1;
		[Signal("skill3-2")] public string Skill3_2;
		[Signal("skill3-3")] public string Skill3_3;
		#endregion
	}
}