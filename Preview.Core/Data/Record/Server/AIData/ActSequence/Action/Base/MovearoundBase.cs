using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.GameData.AIData.ActSequence.Action.Base
{
	public abstract class MovearoundBase : IAction
	{
		#region 字段
		[Signal("max-idle-sec")]
		public int MaxIdleSec;

		[Signal("min-idle-sec")]
		public int MinIdleSec;

		[Signal("max-move-count")]
		public int MaxMoveCount;

		[Signal("min-move-count")]
		public int MinMoveCount;


		public Script_obj Target;
		#endregion
	}
}