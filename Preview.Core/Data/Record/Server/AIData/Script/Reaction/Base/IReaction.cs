using System.ComponentModel;

using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.bns.Modules.AIData.Script.Reaction
{
	public abstract class IReaction : TypeBaseNode<ReactionType>
	{
		[DefaultValue(0)]
		public byte Probability;
	}
}