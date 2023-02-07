using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("dispel-by-type")]
	public sealed class DispelByType : IReaction
	{
		#region 字段
		public Script_obj Target;

		public Script_obj From;



		[Signal("dispel-force")]
		public bool DispelForce;

		[Signal("effect-type")]
		public string EffectType;
		#endregion
	}
}