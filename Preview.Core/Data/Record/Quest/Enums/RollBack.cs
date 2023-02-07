
using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.Quest.Enums
{
	/// <summary>
	/// 回滚类型
	/// </summary>
	public enum RollBack
	{
		None,

		[Signal("leave-world")]
		LeaveWorld,

		[Signal("leave-zone")]
		LeaveZone,

		[Signal("remove-fielditem")]
		RemoveFieldItem,
	}
}