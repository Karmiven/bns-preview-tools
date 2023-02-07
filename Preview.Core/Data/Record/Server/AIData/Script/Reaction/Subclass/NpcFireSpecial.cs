using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 使用指定的特殊战斗序列
	/// </summary>
	[Signal("npc-fire-special")]
	public sealed class NpcFireSpecial : IReaction
	{
		#region 字段
		public Script_obj Target;

		/// <summary>
		/// 特殊序列编号
		/// </summary>
		[Signal("special-id")]
		public byte SpecialId;


		public Script_obj Requester;
		#endregion
	}
}