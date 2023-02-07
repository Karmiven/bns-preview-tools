using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class AttractionPopup : CaseBase
	{
		#region 字段
		[Signal("attraction-popup-env")]
		public ZoneEnv2 AttractionPopupEnv;
		#endregion
	}
}