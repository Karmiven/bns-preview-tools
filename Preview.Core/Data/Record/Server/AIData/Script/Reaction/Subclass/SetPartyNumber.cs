using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("set-party-number")]
	public sealed class SetPartyNumber : IReaction
	{
		#region 字段
		public Script_obj Target;

		public byte Reg;

		public int Amount;
		#endregion
	}
}