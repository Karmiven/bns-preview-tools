using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.Quest.Enums
{
	public enum GadgetRequired
	{
		[Signal("dont-care")]
		DontCare,

		[Signal("carry-and-remove")]
		CarryAndRemove,

		Carry,

		Empty,

		[Signal("not-A")]
		NotA,
	}
}