using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 设置NPC活动
	/// </summary>
	[Signal("set-npc-act")]
	public sealed class SetNpcAct : IReaction
	{
		#region 字段
		public Script_obj Target;

		/// <summary>
		/// 引用 ActSequence 对象
		/// </summary>
		public string Seq;
		#endregion
	}
}