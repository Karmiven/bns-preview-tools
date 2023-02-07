
using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.Quest.Enums
{
	public enum BroadcastCategory
	{
		None,

		Field,

		Always,

		[Signal("solo-quartet")]
		SoloQuartet,

		Sextet,
	}
}