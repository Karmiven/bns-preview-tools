using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.AIData.CombatSequence.Enums;
using Xylia.Preview.Data.Table.XmlRecord;


namespace Xylia.bns.Modules.AIData.CombatSequence
{
	[Signal("combat-sequence")]
	public sealed class CombatSequence : BaseNode
	{
		#region 字段
		public string Alias;

		[Signal("hide-seq-start")]
		public bool HideSeqStart;

		/// <summary>
		/// 开始时社交
		/// </summary>
		[Signal("seq-start-social")]
		public byte SeqStartSocial;

		/// <summary>
		/// 激活调试模式
		/// </summary>
		[Signal("script-debug-enable")]
		public bool ScriptDebugEnable;

		/// <summary>
		/// 转移条件 1
		/// </summary>
		[Signal("transit-cond-1")]
		public TransitCond TransitCond1;

		/// <summary>
		/// 转移条件 2
		/// </summary>
		[Signal("transit-cond-2")]
		public TransitCond TransitCond2;

		[Signal("transit-action-1")]
		public TransitAction TransitAction1;

		[Signal("transit-action-2")]
		public TransitAction TransitAction2;

		[Signal("transit-social-1")]
		public byte TransitSocial1;

		[Signal("transit-social-2")]
		public byte TransitSocial2;
		#endregion

		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<Normal> Normals = new();

		[FStruct(StructType.Meta)]
		public List<Special> Specials = new();
		#endregion

		#region	方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);

			this.Normals = BaseNode.LoadChildren<Normal>(xe, "normal");
			this.Specials = BaseNode.LoadChildren<Special>(xe, "special");
        }
		#endregion
	}
}