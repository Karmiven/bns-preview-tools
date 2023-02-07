using System.Collections.Generic;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class EnterPortal : CaseBase
	{
		#region 字段
		public string Object2;
		#endregion

		#region 方法
		public override List<string> AttractionObject => new() { Object2 };
		#endregion
	}
}