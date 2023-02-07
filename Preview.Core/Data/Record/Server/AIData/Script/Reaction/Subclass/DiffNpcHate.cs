using Xylia.Attribute.Component;

using Xylia.bns.Modules.AIData.Script.Reaction.Base;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("diff-npc-hate")]
	public sealed class DiffNpcHate : NpcHateBase
	{
		#region 字段
		public int Amount;

		#endregion
	}
}