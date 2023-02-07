using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("play-indexed-social")]
	public sealed class PlayIndexedSocial : IReaction
	{
		#region 字段
		public Script_obj From;

		/// <summary>
		/// 可缺省
		/// </summary>
		public Script_obj To;


		public byte Social;

		[Signal("play-social-delay")]
		public int PlaySocialDelay;
		#endregion
	}
}