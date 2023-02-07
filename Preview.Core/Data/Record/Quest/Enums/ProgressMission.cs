using System.ComponentModel;

using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.Quest.Enums
{
	[DefaultValue(None)]
	public enum ProgressMission
	{
		None,

		[Signal("reaction-only")]
		ReactionOnly,

		Y,

		N,
	}
}