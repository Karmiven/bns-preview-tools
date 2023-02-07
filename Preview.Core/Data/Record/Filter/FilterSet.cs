using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Table.XmlRecord;


namespace Xylia.bns.Modules.GameData.Filter
{
	[Signal("filter-set")]
	public sealed class FilterSet : BaseNode
	{
		#region 字段
		[Side(Side.Type.Client)]
		public string Name;

		[FStruct(StructType.Meta)]
		public List<Filter> Filters;
		#endregion


		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);

			this.Filters = BaseNode.LoadChildren<Filter>(xe, "filter");
		}
		#endregion
	}
}