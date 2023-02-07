using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.AIData.Script.Decision;
using Xylia.bns.Modules.AIData.Script.Entities.Decision;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.bns.Modules.AIData.Script
{
	public sealed class Script : BaseRecord
	{
		#region 字段
		public string Parent;

		public HangerSeq Hanger;

		public enum HangerSeq
		{
			None,

			Object,
		}
		#endregion

		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<IDecision> Decisiones = new();
		#endregion



		#region 方法
		public override void LoadData(XmlElement data)
		{
			BaseNode.LoadData(this, data);

			//this.Decisiones = new(() =>
			//{
			var tmp = new List<IDecision>();
			var DecisionN = data.SelectNodes("./decision|./quest-decision");
			for (int i = 0; i < DecisionN.Count; i++)
			{
				IDecision DecisionEntity = null;

				var CurNode = (XmlElement)DecisionN[i];
				if (CurNode.Name == "decision") DecisionEntity = new Decision.Decision();
				else if (CurNode.Name == "quest-decision") DecisionEntity = new QuestDecision();

				DecisionEntity.LoadData(CurNode);
				tmp.Add(DecisionEntity);
			}

			//return tmp;
			//});
		}
		#endregion
	}
}