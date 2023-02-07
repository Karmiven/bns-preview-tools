using System;

using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("heal-max")]
	public sealed class HealMax : IReaction
	{
		#region 字段
		[Obsolete]
		public Script_obj Target;

		public Script_obj Target2;
		#endregion
	}
}