using Xylia.Attribute.Component;

using static Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class EquipItem : TutorialCaseBase
	{
		[Side(Side.Type.Client)]
		[Signal("item-category")]
		public GameCategory2Seq ItemCategory;
		
		[Side(Side.Type.Client)]
		public Item Item;
	}
}