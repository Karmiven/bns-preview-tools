using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 转移战斗序列（指定）
	/// </summary>
	[Signal("transit-npc-combat-index")]
	public sealed class TransitNpcCombatIndex : TransitNpcCombat
	{
		#region 字段
		/// <summary>
		/// 转移战斗序列索引 (智力参数索引)   索引从1开始
		/// </summary>
		public byte Index;
		#endregion
	}
}