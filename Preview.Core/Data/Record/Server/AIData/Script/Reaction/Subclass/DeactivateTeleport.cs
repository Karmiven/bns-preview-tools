using Xylia.Attribute.Component;
using  Xylia.Preview.Data.Record;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("deactivate-teleport")]
	public sealed class DeactivateTeleport : IReaction
	{
		#region 字段
		public Script_obj Target;

		public Teleport Teleport;
		#endregion
	}
}