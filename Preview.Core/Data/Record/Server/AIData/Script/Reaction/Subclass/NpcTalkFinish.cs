using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("npc-talk-finish")]
	public sealed class NpcTalkFinish : IReaction
	{
		#region 字段
		public Script_obj Npc;
		#endregion
	}
}