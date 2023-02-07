using System.ComponentModel;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class NpcBleeding : TutorialCaseBase
	{
		#region 字段

		#endregion
	}

	public sealed class PcBleeding : TutorialCaseBase
	{
		#region 字段
		[DefaultValue(null)]
		public byte Percent;
		#endregion
	}
}