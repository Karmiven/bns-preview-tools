using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 挑战模式阶段开始
	/// </summary>
	[Signal("pattern-start")]
	public sealed class PatternStart : IReaction
	{
		#region 字段
		public byte Index;
		#endregion
	}
}