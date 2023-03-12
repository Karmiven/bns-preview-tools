using System.Collections.Generic;

using Xylia.Preview.Common.Attribute;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class PcSocial : CaseBase
	{
		public string Object2;

		[Side(Side.Type.Client)]
		public TalkSocial Social;

		[Side(Side.Type.Client)]
		[Signal("state-social")]
		public StateSocial StateSocial;

		[Side(Side.Type.Client)]
		[Signal("npc-response")]
		public NpcResponse NpcResponse;


		public override List<string> AttractionObject => new() { Object2 };
	}
}