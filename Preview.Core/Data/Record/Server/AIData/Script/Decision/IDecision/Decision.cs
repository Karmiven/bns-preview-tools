using Xylia.bns.Modules.AIData.Script.Entities.Decision;


namespace Xylia.bns.Modules.AIData.Script.Decision
{
	public sealed class Decision : IDecision
	{
		#region 字段
		/// <summary>
		/// 事件类型
		/// </summary>
		public EventType Event;

		/// <summary>
		/// 继承母对象的当前事件
		/// </summary>
		public bool Forward;

		/// <summary>
		/// 此字段可能是错写
		/// </summary>
		public bool Foward;
		#endregion
	}
}
