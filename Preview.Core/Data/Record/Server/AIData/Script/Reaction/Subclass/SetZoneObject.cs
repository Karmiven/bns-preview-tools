using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("set-zone-object")]
	public sealed class SetZoneObject : IReaction
	{
		#region 字段
		public Script_obj Object;

		public byte Zreg;
		#endregion
	}
}