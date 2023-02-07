using System.Collections.Generic;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class Airdash : TutorialCaseBase
	{
		#region 字段
		[Side(Side.Type.Client)]
		public string Object2;

		[Side(Side.Type.Client)]
		[Signal("env-response")]
		public string EnvResponse;
		#endregion


		public override List<string> AttractionObject  => new() { Object2 };
	}
}