using Xylia.Attribute.Component;
using Xylia.bns.Modules.AIData.CombatSequence.Action.Base;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	[Signal("use-ground-skill")]
	public sealed class UseGroundSkill : SkillBase
	{
		#region 字段
		/// <summary>
		/// 目标区域
		/// </summary>
		[Signal("target-area")]
		public string TargetArea;

		[Signal("target-area-ref")]
		public int TargetAreaRef;

		/// <summary>
		/// 目标坐标
		/// </summary>
		[Signal("target-pos")]
		public string TargetPos;
		#endregion
	}
}