using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record
{
	[AliasRecord]
	public sealed class Faction : BaseRecord
	{
		#region 属性字段
		public Text Name2;

		[Signal("tag-name")]
		public Text TagName;


		public string Icon;

		public Text Text;
		#endregion
	}
}