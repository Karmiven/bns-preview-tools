using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class TeleportZone : TutorialCaseBase
	{
		#region 字段
		[Side(Side.Type.Client)]
		[Signal("teleport-id")]
		public Teleport TeleportID;
		#endregion
	}
}