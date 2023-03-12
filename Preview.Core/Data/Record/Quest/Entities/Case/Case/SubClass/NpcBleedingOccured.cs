using System.Collections.Generic;

using Xylia.Preview.Common.Attribute;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class NpcBleedingOccured : CaseBase
	{
		public string Object;

		[Side(Side.Type.Server)]
		public byte Idx;


		public override List<string> AttractionObject => new() { Object };
	}
}