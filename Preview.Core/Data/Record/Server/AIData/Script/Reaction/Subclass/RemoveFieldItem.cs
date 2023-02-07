using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("remove-field-item")]
	public sealed class RemoveFieldItem : IReaction
	{
		#region 字段
		public Script_obj Target;

		public string Spawn1;
		public string Spawn2;
		#endregion
	}
}