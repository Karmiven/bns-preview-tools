using Xylia.Attribute.Component;

namespace Xylia.Preview.Common.Seq
{
	/// <summary>
	/// 战斗序列转移类型
	/// </summary>
	public enum TransitType
	{
		None,

		/// <summary>
		/// 事件转移
		/// </summary>
		[Signal("by-event")]
		ByEvent,

		/// <summary>
		/// 定时器转移
		/// </summary>
		[Signal("by-timer")]
		ByTimer,
	}
}