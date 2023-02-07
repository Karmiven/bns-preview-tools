using Xylia.Attribute.Component;

using  Xylia.Preview.Data.Record;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{

	[Signal("in-out-detect-start")]
	public sealed class InOutDetectStart : IReaction
	{
		#region 字段
		public int Duration;

		/// <summary>
		/// 引用 Filter 对象
		/// </summary>
		[Signal("filter-1")]
		public Filter Filter1;

		[Signal("filter-2")]
		public Filter Filter2;

		[Signal("filter-3")]
		public Filter Filter3;

		[Signal("filter-4")]
		public Filter Filter4;




		/// <summary>
		/// 半径
		/// </summary>
		public short Radius;


		[Signal("ref-type")]
		public RefType RefType;

		[Signal("ref-object")]
		public Script_obj RefObject;

		[Signal("ref-area")]
		public ZoneArea RefArea;



		public Script_obj Subscriber;

		[Signal("gather-count")]
		public byte GatherCount;

		public byte Index;
		#endregion
	}


	public enum RefType
	{
		Area,

		Object,
	}
}