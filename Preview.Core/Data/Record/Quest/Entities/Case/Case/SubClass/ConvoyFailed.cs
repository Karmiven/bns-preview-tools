using System.Collections.Generic;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	/// <summary>
	/// 护送失败
	/// </summary>
	public sealed class ConvoyFailed : CaseBase
	{
		#region 字段
		public string Object;

		public ZoneConvoy Convoy;
		#endregion

		#region 方法
		public override List<string> AttractionObject => new() { Object };
		#endregion
	}
}