using Xylia.Preview.Common.Seq;

namespace Xylia.bns.Modules.GameData.AIData.ActSequence.Action.Subclass
{
	public sealed class Stay : IAction
	{
		#region 字段
		public long Duration;

		public Detect detect;

		public byte Repeat;
		#endregion
	}
}
