using Xylia.Attribute.Component;

using  Xylia.Preview.Data.Record;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("set-public-raid-event")]
	public sealed class SetPublicRaidEvent : IReaction
	{
		#region 字段
		[Signal("public-raid-event")]
		public PublicRaidEvent PublicRaidEvent;
		#endregion
	}
}