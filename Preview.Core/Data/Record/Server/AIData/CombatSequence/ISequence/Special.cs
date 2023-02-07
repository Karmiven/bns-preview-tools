using Xylia.Attribute.Component;

using Xylia.Preview.Common.Seq;

namespace Xylia.bns.Modules.AIData.CombatSequence
{
	/// <summary>
	/// 特殊序列
	/// </summary>
	public sealed class Special : ISequence
	{
		/// <summary>
		/// 条件
		/// </summary>
		[Signal("condition-1")]
		public Flag Condition1;

		/// <summary>
		/// 条件
		/// </summary>
		[Signal("condition-2")]
		public Flag Condition2;

		/// <summary>
		/// 条件对象 默认是 event:npc-combat-action:target
		/// </summary>
		[Signal("condition-subscription-1")]
		public Script_obj ConditionSubscription1;

		/// <summary>
		/// 条件对象
		/// </summary>
		[Signal("condition-subscription-2")]
		public Script_obj ConditionSubscription2;




		[Signal("start-delay")]
		public int StartDelay;

		[Signal("min-delay")]
		public int MinDelay;
	}
}	