using Xylia.Attribute.Component;

using  Xylia.Preview.Data.Record;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("play-cinematic")]
	public sealed class PlayCinematic : IReaction
	{
		#region 字段
		/// <summary>
		/// 引用 Cinematic 对象
		/// </summary>
		public Cinematic Cinematic;

		public Sight Sight;

		public Script_obj To;
		#endregion
	}

	public enum Sight
	{
		None,

		One,

		Party,

		Team,	

		Zone,
	}
}