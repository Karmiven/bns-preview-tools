using System;

using Xylia.Attribute.Component;
using Xylia.Preview.Common.Seq;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Base
{
	public abstract class SkillBase : IAction
	{
		#region 字段
		[Obsolete]
		public string Skill;

		/// <summary>
		/// 技能
		/// </summary>
		public string Skill3;


		public Script_obj Target;

		[Signal("except-condition")]
		public Flag ExceptCondition;

		[Signal("except-link-laser")]
		public bool ExceptLinkLaser;

		/// <summary>
		/// 排除召唤兽对象
		/// </summary>
		[Signal("except-summoned")]
		public bool ExceptSummoned;

		[Signal("exclude-summoned")]
		public bool ExcludeSummoned;

		/// <summary>
		/// 排除主仇恨对象
		/// </summary>
		[Signal("except-top-hate")]
		public bool ExceptTopHate;

		[Signal("replace-top-hate")]
		public bool ReplaceTopHate;
		#endregion
	}
}