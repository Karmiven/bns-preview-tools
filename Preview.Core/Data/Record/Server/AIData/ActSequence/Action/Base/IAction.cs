using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.bns.Modules.GameData.AIData.ActSequence.Action
{
	public abstract class IAction : TypeBaseNode<ActionType>
	{
		/// <summary>
		/// 仅当上级节点是 Select 时才有意义
		/// </summary>
		public byte Prob;
	}
}