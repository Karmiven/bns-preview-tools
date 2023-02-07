using System;

using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 设置 Env 初始激活状态
	/// </summary>
	[Signal("set-env-init-enable")]
	public sealed class SetEnvInitEnable : IReaction
	{
		#region 字段
		[Obsolete]
		public Script_obj Target1;

		public Script_obj Target2;

		[Signal("init-enable")]
		public bool InitEnable;
		#endregion
	}
}