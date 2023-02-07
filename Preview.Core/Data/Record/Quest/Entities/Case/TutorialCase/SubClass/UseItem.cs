using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class UseItem : TutorialCaseBase
	{
		[Side(Side.Type.Client)]
		public string Item;
	}
}