using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class PublicRaid : BaseRecord, Attraction
	{
		[Signal("publicraid-name2")]
		public Text PublicraidName2;

		[Signal("publicraid-desc")]
		public Text PublicraidDesc;

		[Signal("reward-summary")]
		public AttractionRewardSummary RewardSummary;

		[Signal("publicraid-icon")]
		public string PublicraidIcon;

		[Signal("publicraid-image")]
		public string PublicraidImage;


		#region 接口方法
		public string GetName() => this.PublicraidName2.GetText();

		public string GetDescribe() => this.PublicraidDesc.GetText();
		#endregion
	}
}