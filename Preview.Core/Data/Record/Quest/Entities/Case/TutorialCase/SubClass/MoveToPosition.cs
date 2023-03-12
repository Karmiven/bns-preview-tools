using Xylia.Preview.Common.Attribute;
using  Xylia.Preview.Data.Record;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class MoveToPosition : TutorialCaseBase
	{
		[Side(Side.Type.Client)]
		[Signal("link-npc")]
		public Npc LinkNpc;

		[Side(Side.Type.Client)]
		[Signal("location-x")]
		public float LocationX;

		[Side(Side.Type.Client)]
		[Signal("location-y")]
		public float LocationY;

		[Side(Side.Type.Client)]
		[Signal("approach-range")]
		public float ApproachRange;
	}
}