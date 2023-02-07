using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.Script.Reaction.Subclass
{
	/// <summary>
	/// 重置区域对象
	/// </summary>
	[Signal("reset-zone-object")]
	public sealed class ResetZoneObject : IReaction
	{
		#region 字段
		public byte zreg;
		#endregion
	}
}