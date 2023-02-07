using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 挑战奖励
	/// </summary>
	public sealed class ChallengeListReward : BaseRecord
	{
		[Signal("reward-money")]
		public int RewardMoney;

		[Signal("reward-account-exp")]
		public int RewardAccountExp;
	}
}
