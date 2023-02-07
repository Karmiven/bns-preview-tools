using Xylia.Attribute.Component;

using  Xylia.Preview.Data.Record;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("play-surround-social")]
	public sealed class PlaySurroundSocial : IReaction
	{
		#region 字段
		public Script_obj From;

		public Script_obj To;

		public Social Social;

		[Signal("play-social-delay")]
		public int PlaySocialDelay;
		#endregion
	}
}