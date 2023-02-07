using Xylia.Attribute.Component;
using  Xylia.Preview.Data.Record;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class GrowItem : TutorialCaseBase
	{
		#region 字段
		[Side(Side.Type.Client)]
		[Signal("material-item")]
		public Item MaterialItem;

		[Side(Side.Type.Client)]
		[Signal("primary-item")]
		public Item PrimaryItem;
		#endregion
	}
}