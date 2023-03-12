using Xylia.Preview.Common.Attribute;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	[AliasRecord]
	public sealed class Duel : BaseRecord, Attraction
	{
		[Signal("duel-name2")]
		public Text DuelName2;

		[Signal("duel-desc")]
		public Text DuelDesc;

		[Signal("reward-summary")]
		public AttractionRewardSummary RewardSummary;
	
		#region 接口方法
		public string GetName() => this.DuelName2.GetText();

		public string GetDescribe() => this.DuelDesc.GetText();
		#endregion
	}
}