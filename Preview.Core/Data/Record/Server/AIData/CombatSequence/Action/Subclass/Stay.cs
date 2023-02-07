namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	/// <summary>
	/// 等待 <see cref="IAction.Duration"/> (ms)
	/// </summary>
	public sealed class Stay : IAction
	{
		#region 字段
		public Script_obj Target;
		#endregion
	}
}
