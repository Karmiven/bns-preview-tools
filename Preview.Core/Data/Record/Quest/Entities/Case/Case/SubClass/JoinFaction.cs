using System.Collections.Generic;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class JoinFaction : CaseBase
	{
		#region 字段
		public Faction Faction;

		public string Object;

		[Signal("npc-response-1")]
		public NpcResponse NpcResponse1;

		[Signal("npc-response-2")]
		public NpcResponse NpcResponse2;

		[Signal("npc-response-3")]
		public NpcResponse NpcResponse3;

		#endregion

		#region 方法
		public override List<string> AttractionObject => new() { Object };
		#endregion
	}
}