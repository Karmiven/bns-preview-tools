using Xylia.Attribute.Component;
using Xylia.bns.Modules.AIData.CombatSequence.Enums;


namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	/// <summary>
	/// 战斗移动
	/// </summary>
	[Signal("combat-move")]
	public sealed class CombatMove : IAction
	{
		#region 字段
		[Signal("move-msec")]
		public int MoveMsec;

		/// <summary>
		/// 移动类型
		/// </summary>
		[Signal("move-type")]
		public MoveType MoveType;

		[Signal("range-within")]
		public short RangeWithin;
		#endregion
	}
}