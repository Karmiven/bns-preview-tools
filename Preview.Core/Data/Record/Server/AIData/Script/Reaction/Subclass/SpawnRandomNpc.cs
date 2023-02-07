using Xylia.Attribute.Component;

using Xylia.bns.Modules.AIData.Script.Reaction.Base;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("spawn-random-npc")]
	public sealed class SpawnRandomNpc : SpawnNpcBase
	{
		#region 字段
		//public byte Probability;


		public Script_obj Group;

		public byte Min;

		public byte Max;

		public byte Start;

		public byte End;
		#endregion
	}
}