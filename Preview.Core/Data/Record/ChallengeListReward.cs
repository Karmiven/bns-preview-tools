using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record
{
	[AliasRecord]
	public sealed class ChallengeListReward : BaseRecord
	{
		[Signal("reward-money")]
		public int RewardMoney;

		[Signal("reward-account-exp")]
		public int RewardAccountExp;
	}
}