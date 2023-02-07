using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 增加挑战分数
	/// 允许负值
	/// </summary>
	[Signal("add-zone-score")]
	public sealed class AddZoneScore : IReaction
	{
		#region 字段
		/// <summary>
		/// 分数
		/// </summary>
		public int Score;
		#endregion
	}
}