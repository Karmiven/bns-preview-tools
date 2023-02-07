using Xylia.Attribute.Component;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("set-npc-hate-on")]
	public sealed class SetNpcHateOn : IReaction
	{
		#region 字段
		public Script_obj Target;

		public bool Flag;
		#endregion
	}
}