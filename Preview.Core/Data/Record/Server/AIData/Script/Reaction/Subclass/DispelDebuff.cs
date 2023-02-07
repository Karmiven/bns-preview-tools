using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 清除负面效果
	/// </summary>
	[Signal("dispel-debuff")]
	public sealed class DispelDebuff : IReaction
	{
		#region 字段
		public Script_obj Target;
		#endregion
	}
}