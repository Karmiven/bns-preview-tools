using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.ContextScriptData
{
	public sealed class Stance : BaseNode
	{
		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<Layer> Layers;
		#endregion

		#region 字段
		[Signal("abnormal-flag")]
		public Flag AbnormalFlag;

		public StanceSeq stance;

		public LinkType Link;
		#endregion

		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);
			this.Layers = BaseNode.LoadChildren<Layer>(xe, "layer");
		}
		#endregion
	}
}