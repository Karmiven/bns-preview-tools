using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 委托效果
	/// </summary>
	[Signal("invoke-effect")]
	public sealed class InvokeEffect : IReaction
	{
		#region 字段
		public Script_obj Target;

		public string Effect;


		
		/// <summary>
		/// SoulMask 类型效果必须设置此字段
		/// </summary>
		public Script_obj Caster;

		public Script_obj Invoker;


		public bool Immediately;

		public Script_obj From;
		#endregion
	}
}