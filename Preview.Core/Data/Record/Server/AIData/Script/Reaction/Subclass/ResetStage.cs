using Xylia.Attribute.Component;
using  Xylia.Preview.Data.Record;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("reset-stage")]
	public sealed class ResetStage : IReaction
	{
		#region 字段
		public Script_obj Target;

		[Signal("reset-stage")]
		public NpcResetStage resetStage;
		#endregion
	}
}