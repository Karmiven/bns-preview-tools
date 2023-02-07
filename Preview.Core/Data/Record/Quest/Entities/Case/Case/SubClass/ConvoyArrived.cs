using System.Collections.Generic;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	/// <summary>
	/// 护送成功
	/// </summary>
	public sealed class ConvoyArrived : CaseBase
	{
		#region 字段
		public string Object;

		[Side(Side.Type.Server)]
		public ZoneConvoy Convoy;
		#endregion

		#region 方法
		public override List<string> AttractionObject => new() { Object };
		#endregion
	}
}