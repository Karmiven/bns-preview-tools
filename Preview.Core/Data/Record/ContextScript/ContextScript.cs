using System.Collections.Generic;
using System.Linq;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Record.ContextScriptData;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record
{
	[AliasRecord]
	public sealed class ContextScript : BaseRecord
	{
		#region 字段
		[Signal("context-simple-mode")]
		public bool ContextSimpleMode;

		public RaceSeq Race;

		public JobSeq Job;

		[Signal("job-style-1")]
		public JobStyleSeq JobStyle1;

		[Signal("job-style-2")]
		public JobStyleSeq JobStyle2;


		[FStruct(StructType.Meta)]
		public List<Stance> Stance;
		#endregion

		#region 方法
		public override void LoadData(XmlElement data)
		{
			BaseNode.LoadData(this, data);
			this.Stance = BaseNode.LoadChildren<Stance>(data, "stance");
		}


		public void Test()
		{
			foreach (var stance in this.Stance)
			{
				foreach (var decision in stance.Layers.SelectMany(layer => layer.Decisions))
				{
					var condition = decision.Condition.Find(condition => condition.Skill == 66301);
					if (condition is null) continue;

					var result = decision.Result.Find(result => result.ControlMode == Result.ControlModeSeq.bns);
					//Debug.WriteLine(result.OuterXml);
				}
			}
		}
		#endregion
	}
}