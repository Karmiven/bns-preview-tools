using Xylia.Preview.Common.Attribute;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class GemCompose : TutorialCaseBase
	{
		[Side(Side.Type.Client)]
		[Signal("primary-item")]
		public Item PrimaryItem;

		[Side(Side.Type.Client)]
		[Signal("material-item")]
		public Item MaterialItem;
	}
}