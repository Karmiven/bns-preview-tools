using System;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 伤害
	/// </summary>
	public sealed class Damage : IReaction
	{
		#region 字段
		[Obsolete]
		public Script_obj Target;

		public Script_obj Target2;


		public long Amount;

		public byte Percent;
		#endregion
	}
}