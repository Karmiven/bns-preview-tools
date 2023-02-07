
using Xylia.Attribute.Component;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action
{
	public abstract class IAction : TypeBaseNode<ActionType>
	{
		#region 字段
		public bool Combo;

		/// <summary>
		/// 执行时长 (Msec)
		/// </summary>
		public int Duration;

		/// <summary>
		/// 特殊事件步骤
		/// 只有 special子节点 可以使用
		/// </summary>
		[Signal("event-step")]
		public byte EventStep;


		public byte Repeat;

		[Signal("immune-breaker-disable")]
		public bool ImmuneBreakerDisable;

		/// <summary>
		/// 仅当上级节点是 Select 时才有意义
		/// </summary>
		public byte Prob;
		#endregion
	}
}