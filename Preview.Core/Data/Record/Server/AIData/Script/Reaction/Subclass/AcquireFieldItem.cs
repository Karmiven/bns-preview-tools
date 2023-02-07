using Xylia.Attribute.Component;

using  Xylia.Preview.Data.Record;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("acquire-field-item")]
	public sealed class AcquireFieldItem : IReaction
	{
		#region 字段
		public Script_obj Target;

		[Signal("field-item")]
		public FieldItem FieldItem;
		#endregion
	}
}