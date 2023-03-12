using System.Collections.Generic;

using Xylia.Preview.Common.Attribute;

namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class Airdash : TutorialCaseBase
	{
		[Side(Side.Type.Client)]
		public string Object2;

		[Side(Side.Type.Client)]
		[Signal("env-response")]
		public string EnvResponse;


		public override List<string> AttractionObject  => new() { Object2 };
	}
}