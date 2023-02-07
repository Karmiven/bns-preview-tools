using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.GameData.AIData.ActSequence.Action.Subclass
{
	public sealed class Select : IAction
	{
		#region 字段
		[Signal("enter-prob")]
		public byte EnterProb;

		#endregion
	}
}