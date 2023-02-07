using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 挑战模式阶段成功
	/// </summary>
	[Signal("pattern-success")]
	public sealed class PatternSuccess : IReaction
	{
		#region 字段
		public byte Index;
		#endregion
	}
}