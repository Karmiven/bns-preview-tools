using Xylia.Attribute.Component;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 设置NPC可被攻击
	/// </summary>
	[Signal("set-npc-attackable")]
	public sealed class SetNpcAttackable : IReaction
	{
		#region 字段
		public Script_obj Target;

		public bool Flag;
		#endregion
	}
}