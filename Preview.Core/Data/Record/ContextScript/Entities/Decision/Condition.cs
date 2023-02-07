
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.ContextScriptData
{
	/// <summary>
	/// 使用条件
	/// </summary>
	public sealed class Condition : BaseNode
	{
		#region 字段
		public int Skill;

		[Signal("variation-id")]
		public byte VariationId;

		[Signal("job-style")]
		public JobStyleSeq JobStyle;

		[Signal("skip-condition-link-check")]
		public bool SkipConditionLinkCheck;

		[Signal("skip-condition-move-check")]
		public bool SkipConditionMoveCheck;

		[Signal("skip-condition-target-check")]
		public bool SkipConditionTargetCheck;

		public FieldSeq Field;


		[Signal("combination-key-command-1")]
		public KeyCommandSeq CombinationKeyCommand1;

		[Signal("combination-key-command-2")]
		public KeyCommandSeq CombinationKeyCommand2;
		#endregion

		#region 枚举
		public enum FieldSeq
		{
			 [Signal("job-style-only")] 
			JobStyleOnly,

			 State,

			 Combo,
		}
		#endregion
	}
}