using System.ComponentModel;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.QuestData
{
	[Signal("not-acquire")]
	public sealed class NotAcquire : BaseNode
	{
		#region 字段
		[DefaultValue(null)]
		[Signal("zone-index")]
		public byte ZoneIndex;

		[Side(Side.Type.Client)]
		public string Kismet;
		#endregion
	}
}