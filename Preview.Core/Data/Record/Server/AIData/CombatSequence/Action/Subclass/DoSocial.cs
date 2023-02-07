using Xylia.Attribute.Component;
using Xylia.bns.Modules.AIData.CombatSequence.Action.Base;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	/// <summary>
	/// 执行特定社交
	/// </summary>
	[Signal("do-social")]
	public sealed class DoSocial : SkillBase
	{
		#region 字段
		public string Social;
		#endregion
	}
}