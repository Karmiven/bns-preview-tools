using Xylia.Attribute.Component;

using Xylia.Preview.Common.Seq;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("dispel-by-attr")]
	public sealed class DispelByAttr : IReaction
	{
		#region 字段
		public Script_obj Target;

		public EffectAttribute Attr;
		#endregion
	}
}