using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("set-npc-indexed-act")]
	public sealed class SetNpcIndexedAct : IReaction
	{
		#region 字段
		[Signal("seq-idx")]
		public byte SeqIdx;

		public Script_obj Target;
		#endregion
	}
}