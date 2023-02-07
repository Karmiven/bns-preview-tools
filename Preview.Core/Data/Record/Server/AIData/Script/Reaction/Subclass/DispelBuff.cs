using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 清除效果
	/// </summary>
	[Signal("dispel-buff")]
	public sealed class DispelBuff : IReaction
	{
		#region 字段
		public Script_obj Target;
		#endregion
	}
}