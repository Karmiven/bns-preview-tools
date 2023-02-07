using Xylia.Attribute.Component;

using Xylia.bns.Modules.AIData.Script.Reaction.Base;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 设置NPC战斗模式
	/// </summary>
	[Signal("set-npc-combat-mode")]
	public sealed class SetNpcCombatMode : NpcBase
	{
		#region 字段
		public Script_obj Target;

		[Signal("combat-mode")]
		public bool CombatMode;

		[Signal("attack-target")]
		public Script_obj AttackTarget;
		#endregion
	}
}