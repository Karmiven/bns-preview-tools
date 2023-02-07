using System;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	public sealed class Heal : IReaction
	{
		#region 字段
		[Obsolete]
		public Script_obj Target;

		public Script_obj Target2;


		public byte Percent;
		#endregion
	}
}
