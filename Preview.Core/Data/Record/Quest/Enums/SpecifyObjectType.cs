using System.ComponentModel;

using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.Quest.Enums
{
	/// <summary>
	/// 特定对象类型
	/// </summary>
	[DefaultValue(SpecificID)]
	public enum SpecifyObjectType
	{
		[Signal("specific-id")]
		SpecificID,

		[Signal("pc")]
		Pc,

		[Signal("duelbot")]
		DuelBot,
	}
}