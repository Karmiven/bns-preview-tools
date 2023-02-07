using System.ComponentModel;

using Xylia.Attribute.Component;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.bns.Modules.GameData.Filter
{
	public class Filter : BaseNode
	{
		#region 字段
		public string Field;

		[DefaultValue(null)]
		public Op Op;

		public string Subject;

		public string Subject2;

		public string Type;

		public string Value;

		[Signal("value-1")] 
		public string Value1;

		[Signal("value-2")] 
		public string Value2;

		[Signal("value-3")] 
		public string Value3;

		[Signal("value-4")] 
		public string Value4;

		public string Item;

		public string Quest;

		[Signal("count-op")]
		public Op CountOp = Op.ge;

		public bool Flag;

		public Flag FlagType;
		#endregion

		#region 服务端字段
		[Side(Side.Type.Server)]
		public string Spawn;

		[Side(Side.Type.Server)]
		public bool Leader;

		[Side(Side.Type.Server)]
		public Script_obj Party;
		#endregion
	}
}