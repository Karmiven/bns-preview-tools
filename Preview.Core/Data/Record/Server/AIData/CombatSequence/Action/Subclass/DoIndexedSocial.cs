using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	/// <summary>
	/// 执行社交 (索引)
	/// </summary>
	[Signal("do-indexed-social")]
	public sealed class DoIndexedSocial : IAction
	{
		#region 字段
		public byte Social;
		#endregion
	}
}