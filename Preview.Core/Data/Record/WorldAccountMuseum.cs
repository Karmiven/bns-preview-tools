using System;

using Xylia.Preview.Common.Attribute;
using Xylia.Preview.Common.Seq;

namespace Xylia.Preview.Data.Record
{
	[AliasRecord]
	public sealed class WorldAccountMuseum : BaseRecord
	{
		[Signal("start-time")]
		public DateTime StartTime;

		[Signal("end-time")]
		public DateTime EndTime;

		[Signal("can-not-used")]
		public bool CanNotUsed;

		[Signal("ability-1")]
		public AttachAbility Ability1;

		[Signal("ability-2")]
		public AttachAbility Ability2;

		[Signal("ability-3")]
		public AttachAbility Ability3;

		[Signal("ability-value-1")]
		public int AbilityValue1;

		[Signal("ability-value-2")]
		public int AbilityValue2;

		[Signal("ability-value-3")]
		public int AbilityValue3;

		[Signal("collection-name")]
		public Text CollectionName;

		[Signal("collection-category")]
		public CollectionCategorySeq CollectionCategory;

		public enum CollectionCategorySeq
		{
			[Signal("level-1")]
			Level1,

			[Signal("level-2")]
			Level2,

			[Signal("level-3")]
			Level3,

			[Signal("level-4")]
			Level4,

			Event,

			Favorite,
		}
	}
}