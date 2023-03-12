using Xylia.Preview.Common.Attribute;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class UseItem : TutorialCaseBase
	{
		[Side(Side.Type.Client)]
		public string Item;
	}
}