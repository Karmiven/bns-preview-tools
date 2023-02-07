using System.Collections.Generic;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class EnterZone : CaseBase
	{
		#region 字段
		public string Object;
		#endregion

		#region 方法
		public override List<string> AttractionObject => new() { Object };
		#endregion
	}
}