using System;

using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{

	[Signal("set-env-enable")]
	public sealed class SetEnvEnable : IReaction
	{
		#region 字段
		[Obsolete]
		public Script_obj Target;

		[Obsolete]
		public Script_obj Target1;


		public Script_obj Target2;


		public bool Enable;

		public bool State;
		#endregion
	}
}