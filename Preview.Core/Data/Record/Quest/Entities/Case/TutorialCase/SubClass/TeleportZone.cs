using Xylia.Preview.Common.Attribute;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class TeleportZone : TutorialCaseBase
	{
		[Side(Side.Type.Client)]
		[Signal("teleport-id")]
		public Teleport TeleportID;
	}
}