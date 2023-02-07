using Xylia.Attribute.Component;

using Xylia.Preview.Common.Seq;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Base
{
	public abstract class NpcBase : IReaction
	{
		public bool Attackable;

		[Signal("hate-on")]
		public bool HateOn;

		public NpcBrain Brain;
	}
}