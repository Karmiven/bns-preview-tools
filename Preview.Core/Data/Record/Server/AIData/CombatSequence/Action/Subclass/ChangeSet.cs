using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	/// <summary>
	/// 改变设置
	/// 特征属性都是索引，可能是从智商设置中抽取对象
	/// </summary>
	[Signal("change-set")]
	public sealed class ChangeSet : IAction
	{
		#region 字段
		public byte Stance;

		[Signal("stance-effect-1")]
		public byte StanceEffect1;

		public byte Weapon;
		#endregion
	}
}