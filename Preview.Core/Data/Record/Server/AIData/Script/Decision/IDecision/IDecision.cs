using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Filter;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.bns.Modules.AIData.Script.Decision
{
	public abstract class IDecision : BaseNode
	{
		#region 结构字段
		/// <summary>
		/// 筛选器
		/// </summary>
		[FStruct(StructType.Meta)]
		public List<FilterSet> FilterSets;

		/// <summary>
		/// 执行器
		/// </summary>
		[FStruct(StructType.Meta)]
		public List<ReactionSet> ReactionSets;
		#endregion


		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);

			this.FilterSets = BaseNode.LoadChildren<FilterSet>(xe, "filter-set");
			this.ReactionSets = BaseNode.LoadChildren<ReactionSet>(xe, "reaction-set");
		}
		#endregion
	}
}
