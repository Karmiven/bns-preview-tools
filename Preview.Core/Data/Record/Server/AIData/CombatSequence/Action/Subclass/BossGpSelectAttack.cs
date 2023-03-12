using Xylia.Preview.Common.Attribute;
using Xylia.Preview.Common.Arg;

namespace Xylia.Preview.Data.Record.CombatSequenceData.Action
{
	[Signal("boss-gp-select-attack")]
	public sealed class BossGpSelectAttack : IAction
	{
		public Script_obj Target;

		[Signal("skill3-1")] 
		public Skill3 Skill3_1;

		[Signal("skill3-2")] 
		public Skill3 Skill3_2;

		[Signal("skill3-3")] 
		public Skill3 Skill3_3;

		[Signal("skill3-4")] 
		public Skill3 Skill3_4;

		[Signal("skill3-5")] 
		public Skill3 Skill3_5;

		[Signal("skill3-6")] 
		public Skill3 Skill3_6;

		[Signal("skill3-7")] 
		public Skill3 Skill3_7;

		[Signal("skill3-8")]
		public Skill3 Skill3_8;

		[Signal("skill3-9")] 
		public Skill3 Skill3_9;

		[Signal("skill3-10")] 
		public Skill3 Skill3_10;
	}
}