using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("act-resume")]
	public sealed class ActResume : IReaction
	{
		#region 字段
		public Script_obj Target;
		#endregion
	}
}