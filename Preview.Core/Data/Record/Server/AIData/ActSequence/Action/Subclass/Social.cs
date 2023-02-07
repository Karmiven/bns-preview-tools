using Xylia.Preview.Common.Seq;

namespace Xylia.bns.Modules.GameData.AIData.ActSequence.Action.Subclass
{
	public sealed class Social : IAction
	{
		#region 字段
		public Xylia.Preview.Data.Record.Social social;

		public Detect detect;

		public Script_obj Target;
		#endregion
	}
}
