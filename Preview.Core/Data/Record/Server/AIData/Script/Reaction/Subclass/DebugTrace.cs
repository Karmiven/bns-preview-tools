using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("debug-trace")]
	public sealed class DebugTrace : IReaction
	{
		#region 字段
		public string Text;
		#endregion
	}
}