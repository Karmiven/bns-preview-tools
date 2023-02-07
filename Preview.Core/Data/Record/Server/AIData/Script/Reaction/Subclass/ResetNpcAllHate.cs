using Xylia.Attribute.Component;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 重置全部仇恨
	/// </summary>
	[Signal("reset-npc-all-hate")]
	public sealed class ResetNpcAllHate : IReaction
	{
		#region 字段
		public Script_obj Target;

		[Signal("group-1")]
		public Script_obj Group1;
		#endregion
	}
}