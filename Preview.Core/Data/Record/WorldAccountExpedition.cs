using Xylia.Attribute.Component;
using Xylia.Preview.Common.Seq;

namespace Xylia.Preview.Data.Record
{
	public sealed class WorldAccountExpedition : BaseRecord
	{
		public byte Step;

		[Signal("can-not-used")]
		public bool CanNotUsed;

		public byte Category;

		
		public bool Unknown;

		[Signal("ability-1")]
		public AttachAbility Ability1;

		[Signal("ability-2")]
		public AttachAbility Ability2;

		[Signal("ability-3")]
		public AttachAbility Ability3;

		[Signal("ability-4")]
		public AttachAbility Ability4;

		[Signal("ability-5")]
		public AttachAbility Ability5;

		[Signal("ability-value-1")]
		public int AbilityValue1;

		[Signal("ability-value-2")]
		public int AbilityValue2;

		[Signal("ability-value-3")]
		public int AbilityValue3;

		[Signal("ability-value-4")]
		public int AbilityValue4;

		[Signal("ability-value-5")]
		public int AbilityValue5;


		public Text Name;

		public Text Description;

		public Text Story;

	
		[Signal("tooltip-1")]
		public Text Tooltip1;

		[Signal("tooltip-2")]
		public Text Tooltip2;

		[Signal("tooltip-3")]
		public Text Tooltip3;

		[Signal("tooltip-4")]
		public Text Tooltip4;

		[Signal("tooltip-5")]
		public Text Tooltip5;
	}
}