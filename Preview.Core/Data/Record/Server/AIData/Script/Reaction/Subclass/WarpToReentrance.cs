using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("warp-to-reentrance")]
	public sealed class WarpToReentrance : IReaction
	{
		#region 字段
		public Script_obj Target;
		#endregion
	}
}