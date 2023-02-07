using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("play-social")]
	public sealed class PlaySocial : IReaction
	{
		#region 字段
		public Script_obj From;

		/// <summary>
		/// 可缺省
		/// </summary>
		public Script_obj To;

		/// <summary>
		/// 引用 Social 对象
		/// </summary>
		public string Social;

		[Signal("play-social-delay")]
		public int PlaySocialDelay;
		#endregion
	}
}