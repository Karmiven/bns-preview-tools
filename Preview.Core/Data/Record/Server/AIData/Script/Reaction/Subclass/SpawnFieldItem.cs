using Xylia.Attribute.Component;

using  Xylia.Preview.Data.Record;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	[Signal("spawn-field-item")]
	public sealed class SpawnFieldItem : IReaction
	{
		#region 字段
		public ZoneArea Area;

		[Signal("field-item")]
		public FieldItem FieldItem;
		#endregion
	}
}