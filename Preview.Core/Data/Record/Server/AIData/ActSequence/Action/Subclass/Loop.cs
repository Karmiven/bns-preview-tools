using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.GameData.AIData.ActSequence.Action.Subclass
{
	public sealed class Loop : IAction
	{
		#region 字段
		[Signal("max-count")]
		public int MaxCount;

		[Signal("min-count")]
		public int MinCount;
		#endregion
	}
}