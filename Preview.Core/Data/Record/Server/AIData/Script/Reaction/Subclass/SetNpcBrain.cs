using Xylia.Attribute.Component;

using Xylia.bns.Modules.AIData.Script.Reaction.Base;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 设置NPC智力
	/// </summary>
	[Signal("set-npc-brain")]
	public sealed class SetNpcBrain : NpcBase
	{
		#region 字段
		public Script_obj Npc;

		public Script_obj Target;
		#endregion
	}
}