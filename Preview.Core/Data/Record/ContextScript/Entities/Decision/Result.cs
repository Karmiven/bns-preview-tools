
using Xylia.Attribute.Component;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.ContextScriptData
{
	public sealed class Result : BaseNode
	{
		#region 字段
		[Signal("control-mode")]
		public ControlModeSeq ControlMode;

		[Signal("key-status")]
		public KeyStatusSeq KeyStatus;




		[Signal("cmd-key-down")]
		public int CmdKeyDown;

		[Signal("cmd-key-left")]
		public int CmdKeyLeft;

		[Signal("cmd-key-double-left")]
		public int CmdKeyDoubleLeft;

		[Signal("cmd-key-right")]
		public int CmdKeyRight;

		[Signal("cmd-key-double-right")]
		public int CmdKeyDoubleRight;



		[Signal("context-ui-effect")]
		public UiEffect ContextUiEffect;

		[Signal("context-1")]
		public int Context1;

		[Signal("context-2")]
		public int Context2;

		[Signal("context-3")]
		public int Context3;



		[Signal("skillbar-ui-effect")]
		public UiEffect SkillbarUiEffect;

		[Signal("skillbar-1")]
		public int Skillbar1;

		[Signal("skillbar-2")]
		public int Skillbar2;

		[Signal("skillbar-3")]
		public int Skillbar3;

		[Signal("skillbar-4")]
		public int Skillbar4;

		[Signal("skillbar-5")]
		public int Skillbar5;

		[Signal("skillbar-6")]
		public int Skillbar6;

		[Signal("skillbar-7")]
		public int Skillbar7;

		[Signal("skillbar-8")]
		public int Skillbar8;



		[Signal("special-ui-effect")]
		public UiEffect SpecialUiEffect;


		[Signal("special-1")]
		public int Special1;

		[Signal("special-2")]
		public int Special2;



		[Signal("stance")]
		public int Stance;

		[Signal("stance-ui-effect")]
		public UiEffect StanceUiEffect;


		[Signal("extra-skillbar-1")]
		public int ExtraSkillbar1;

		[Signal("extra-skillbar-2")]
		public int ExtraSkillbar2;

		[Signal("extra-skillbar-3")]
		public int ExtraSkillbar3;

		[Signal("extra-skillbar-4")]
		public int ExtraSkillbar4;

		[Signal("extra-skillbar-5")]
		public int ExtraSkillbar5;
		#endregion

		#region 枚举
		public enum ControlModeSeq
		{
			classic,
			bns,
		}

		public enum KeyStatusSeq
		{
			unpress,
		}


		public enum UiEffect
		{
			Event,

			Combo,

			[Signal("key-change")]
			KeyChange,

			[Signal("immune-break")]
			ImmuneBreak,
		}
		#endregion
	}
}