using System.ComponentModel;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.QuestData
{
	public class Destination : BaseNode
	{
		#region 字段
		[Signal("mission-step-id")]
		public byte MissionStepID;

		[DefaultValue(null)]
		[Signal("zone-index")]
		public byte ZoneIndex;


		[Side(Side.Type.Client)]
		public string Kismet;
		#endregion
	}
}