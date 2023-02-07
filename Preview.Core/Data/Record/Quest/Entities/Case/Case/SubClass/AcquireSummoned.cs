using System.Collections.Generic;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class AcquireSummoned : NpcTalkBase
	{
		#region 字段
		public string Object;

		[Signal("summoned-preset")]
		public SummonedPreset SummonedPreset;
		#endregion

		#region 方法
		public override List<string> AttractionObject => new() { Object };
		#endregion
	}
}