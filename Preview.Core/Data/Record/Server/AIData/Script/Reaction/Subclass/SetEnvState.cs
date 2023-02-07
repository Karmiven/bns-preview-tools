using System;

using Xylia.Attribute.Component;
using Xylia.Preview.Data.Record;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 设置 Env 状态
	/// </summary>
	[Signal("set-env-state")]
	public sealed class SetEnvState : IReaction
	{
		#region 字段
		[Obsolete]
		public Script_obj Target;

		public Script_obj Target2;

		[Obsolete]
		public ZoneEnv2.EnvState State;

		public ZoneEnv2.EnvState State2;
		#endregion
	}
}
