using Xylia.Attribute.Component;

using Xylia.Preview.Common.Seq;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 设置NPC跟随
	/// </summary>
	[Signal("set-npc-follow")]
	public sealed class SetNpcFollow : IReaction
	{
		#region 字段
		public Script_obj Master;

		public Script_obj Npc;

		public Detect Detect;
		#endregion
	}
}