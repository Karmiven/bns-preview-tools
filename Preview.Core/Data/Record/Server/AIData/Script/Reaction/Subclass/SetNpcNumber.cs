using Xylia.Attribute.Component;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 设置NPC的注册值
	/// </summary>
	[Signal("set-npc-number")]
	public class SetNpcNumber : IReaction
	{
		#region 字段
		public Script_obj Target;

		public byte Reg;

		public int Amount;
		#endregion
	}
}