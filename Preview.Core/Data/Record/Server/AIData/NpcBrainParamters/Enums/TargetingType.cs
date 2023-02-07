using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.NpcBrainParameters.Enums
{
	public enum TargetingType
	{
		None,

		[Signal("hate-top")]
		HateTop,

		[Signal("hate-tour")]
		HateTour,
	}
}