using Xylia.Attribute.Component;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("set-npc-interactive")]
	public sealed class SetNpcInteractive : IReaction
	{
		#region 字段
		public Script_obj Target;

		public bool Flag;
		#endregion
	}
}