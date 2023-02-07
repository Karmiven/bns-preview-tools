using System.Collections.Generic;
using System.Xml;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.AIData.ActSequence.Action;
using Xylia.bns.Modules.GameData.AIData.ActSequence.Action.Subclass;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.bns.Modules.AIData.ActSequence
{
	[Signal("act-sequence")]
	public class ActSequence : BaseNode
	{
		#region 字段
		public string Alias;

		public ActType Type;

		public enum ActType
		{
			Act,
			Peace,
		}


		public Detect Detect;

		[Signal("indexed-detect")]
		public byte IndexedDetect;
		#endregion

		#region 结构字段
		[FStruct(StructType.Meta)]
		public List<IAction> Actions = new();
		#endregion


		#region	方法
		public override void LoadData(XmlElement xe)
		{
			base.LoadData(xe);

			this.Actions = new List<IAction>();
			var Actions = xe.SelectNodes("./action");
			for (int idx = 0; idx < Actions.Count; idx++)
			{
				var ActionNode = Actions[idx];
				this.Actions.Add(ActionNode.TypeFactory<ActionType, IAction>(idx, this, (s) => s switch
				{
					ActionType.Despawn => new Despawn(),
					ActionType.Hide => new Hide(),
					ActionType.IndexedMovearound => new IndexedMovearound(),
					ActionType.IndexedPathway => new IndexedPathway(),
					ActionType.IndexedSocial => new IndexedSocial(),
					ActionType.Loop => new Loop(),
					ActionType.Movearound => new Movearound(),
					ActionType.MovearoundForFieldBossSpawn => new MovearoundForFieldBossSpawn(),
					ActionType.MovearoundForRandomSpawn => new MovearoundForRandomSpawn(),
					ActionType.Pause => new Pause(),
					ActionType.Pathway => new Pathway(),
					ActionType.Select => new Select(),
					ActionType.Social => new Social(),
					ActionType.Stay => new Stay(),

					_ => null
				}));
			}
		}
		#endregion
	}
}