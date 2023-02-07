
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class GuildBattleFieldZone : BaseRecord, Attraction
	{
		[Signal("guild-battle-field-zone-name2")]
		public Text GuildBattleFieldZoneName2;

		[Signal("guild-battle-field-zone-desc")]
		public Text GuildBattleFieldZoneDesc;

		[Signal("thumbnail-image")]
		public string ThumbnailImage;

		[Signal("reward-summary")]
		public AttractionRewardSummary RewardSummary;


		#region 接口字段
		public string GetName() => this.GuildBattleFieldZoneName2.GetText();

		public string GetDescribe() => this.GuildBattleFieldZoneDesc.GetText();
		#endregion
	}
}
