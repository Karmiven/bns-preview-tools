using System.Collections.Generic;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class AcquireSummoned : NpcTalkBase
	{
		[Signal("summoned-preset")]
		public SummonedPreset SummonedPreset;


		public override List<string> AttractionObject => new() { Object };
	}
}