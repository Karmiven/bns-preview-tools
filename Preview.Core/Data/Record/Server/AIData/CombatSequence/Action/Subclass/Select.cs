using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;

namespace Xylia.bns.Modules.AIData.CombatSequence.Action.Subclass
{
	public sealed class Select : IAction
	{
		#region 字段
		/// <summary>
		/// 进入概率
		/// </summary>
		[Signal("enter-prob")]
		public byte EnterProb = 100;
		#endregion


		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<IAction> Actions = new();
		#endregion

		#region 方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);


			this.Actions = new List<IAction>();
			var Actions = xe.SelectNodes("./action");
			for (int i = 0; i < Actions.Count; i++)
			{
				var ActionNode = Actions[i];
				this.Actions.Add(ActionNode.ActionFactory(i, this));
			}
		}
		#endregion
	}
}