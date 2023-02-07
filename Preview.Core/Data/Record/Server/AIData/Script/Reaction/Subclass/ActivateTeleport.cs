using Xylia.Attribute.Component;

using  Xylia.Preview.Data.Record;


namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 激活遁地点
	/// </summary>
	[Signal("activate-teleport")]
	public sealed class ActivateTeleport : IReaction
	{
		#region 字段
		public Script_obj Target;

		public Teleport Teleport;
		#endregion
	}
}