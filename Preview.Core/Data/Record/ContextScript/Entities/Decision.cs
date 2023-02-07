using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.ContextScriptData
{
	public sealed class Decision : BaseNode
	{
		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<Condition> Condition;

		[FStruct(StructType.Meta)]
		public List<Result> Result;
		#endregion

		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);

			this.Condition = BaseNode.LoadChildren<Condition>(xe, "condition");
			this.Result = BaseNode.LoadChildren<Result>(xe, "result");
		}
		#endregion
	}
}