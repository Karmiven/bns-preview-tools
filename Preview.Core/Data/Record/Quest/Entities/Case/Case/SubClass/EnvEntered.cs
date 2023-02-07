using System.Collections.Generic;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class EnvEntered : CaseBase
	{
		#region 字段
		public string Object2;

		[Signal("env-response")]
		public EnvResponse EnvResponse;
		#endregion

		#region 方法
		public override List<string> AttractionObject => new() { Object2 };
		#endregion
	}
}