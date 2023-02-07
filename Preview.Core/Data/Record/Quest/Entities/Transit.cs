using System.Collections.Generic;
using System.Linq;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.QuestData
{
	public class Transit : BaseNode
	{
		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);

			this.Destinations = BaseNode.LoadChildren<Destination>(xe, "destination");
			this.Complete = BaseNode.LoadChildren<Complete>(xe, "complete").FirstOrDefault();
		}
		#endregion


		#region 字段
		public byte id;

		public string Zone;
		#endregion

		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<Destination> Destinations = new();

		[FStruct(StructType.Meta)]
		public Complete Complete;

		//[FStruct(StructType.Ref)]
		//public Quest OwnerQuest => this.Owner as Quest;
		#endregion
	}
}