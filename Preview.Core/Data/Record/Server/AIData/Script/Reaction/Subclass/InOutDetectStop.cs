using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("in-out-detect-stop")]
	public sealed class InOutDetectStop : IReaction
	{
		#region 字段
		public byte Index;
		#endregion
	}
}