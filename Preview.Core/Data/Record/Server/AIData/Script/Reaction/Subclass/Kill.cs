using System;

using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	public sealed class Kill : IReaction
	{
		#region 字段
		[Obsolete] 
		[Signal("target")] 
		public Script_obj Target;

		[Signal("target-1")] 
		public Script_obj Target1;

		[Signal("target-2")] 
		public Script_obj Target2;
		#endregion
	}
}