using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	/// <summary>
	/// 侦测生物
	/// </summary>
	[Signal("detect-creature")]
	public sealed class DetectCreature : IAction
	{
		#region 字段
		public short Height;

		public short Radius;
		#endregion
	}
}