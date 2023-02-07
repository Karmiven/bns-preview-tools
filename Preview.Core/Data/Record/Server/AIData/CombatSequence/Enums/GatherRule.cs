using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.CombatSequence.Enums
{
	public enum GatherRule
	{
		/// <summary>
		/// 最远目标
		/// </summary>
		Far,

		/// <summary>
		/// 最小仇恨
		/// </summary>
		[Signal("min-hate")]
		MinHate,

		/// <summary>
		/// 最近目标
		/// </summary>
		Near,

		/// <summary>
		/// 随机目标
		/// </summary>
		Random,

		/// <summary>
		/// 
		/// </summary>
		Rotate,
	}
}