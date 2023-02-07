using Xylia.Attribute.Component;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 设置为不会死亡的状态
	/// </summary>
	[Signal("set-undying")]
	public sealed class SetUndying : IReaction
	{
		#region 字段
		public Script_obj Target;

		public bool Undying;

		public bool Flag;
		#endregion
	}
}