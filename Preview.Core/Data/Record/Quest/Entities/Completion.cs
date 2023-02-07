using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.QuestData
{
	public class Completion : BaseNode
	{
		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);
			this.NextQuests = BaseNode.LoadChildren<NextQuest>(xe, "next-quest");
		}
		#endregion

		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<NextQuest> NextQuests = new();
		#endregion
	}
}