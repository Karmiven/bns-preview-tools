using System.Collections.Generic;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class PcSocial : CaseBase
	{
		#region 字段
		public string Object2;

		[Side(Side.Type.Client)]
		public TalkSocial Social;

		[Side(Side.Type.Client)]
		[Signal("state-social")]
		public StateSocial StateSocial;

		[Side(Side.Type.Client)]
		[Signal("npc-response")]
		public NpcResponse NpcResponse;
		#endregion


		#region 方法
		public override List<string> AttractionObject => new() { Object2 };
		#endregion
	}
}