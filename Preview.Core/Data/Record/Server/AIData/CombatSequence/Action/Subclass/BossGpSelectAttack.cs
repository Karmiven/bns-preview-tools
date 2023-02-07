using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	[Signal("boss-gp-select-attack")]
	public sealed class BossGpSelectAttack : IAction
	{
		#region 字段
		public Script_obj Target;

		[Signal("skill3-1")] 
		public string Skill3_1;

		[Signal("skill3-2")] 
		public string Skill3_2;

		[Signal("skill3-3")] 
		public string Skill3_3;

		[Signal("skill3-4")] 
		public string Skill3_4;

		[Signal("skill3-5")] 
		public string Skill3_5;

		[Signal("skill3-6")] 
		public string Skill3_6;

		[Signal("skill3-7")] 
		public string Skill3_7;

		[Signal("skill3-8")]
		public string Skill3_8;

		[Signal("skill3-9")] 
		public string Skill3_9;

		[Signal("skill3-10")] 
		public string Skill3_10;
		#endregion
	}
}