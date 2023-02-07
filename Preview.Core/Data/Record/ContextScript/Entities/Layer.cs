using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.ContextScriptData
{
	public sealed class Layer : BaseNode
	{
		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<Decision> Decisions;
		#endregion

		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);
			this.Decisions = BaseNode.LoadChildren<Decision>(xe, "decision");
		}
		#endregion
	}
}