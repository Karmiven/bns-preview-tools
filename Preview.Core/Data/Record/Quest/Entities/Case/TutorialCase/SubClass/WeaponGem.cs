
using Xylia.Attribute.Component;


namespace Xylia.Preview.Data.Record.QuestData.TutorialCase
{
	public sealed class DetachWeaponGem : TutorialCaseBase
	{
		[Side(Side.Type.Client)]
		public string Weapon;

		[Side(Side.Type.Client)]
		public string Gem;
	}

	public sealed class WeaponGem : TutorialCaseBase
	{
		[Side(Side.Type.Client)]
		public string Weapon;

		[Side(Side.Type.Client)]
		public string Gem;
	}
}