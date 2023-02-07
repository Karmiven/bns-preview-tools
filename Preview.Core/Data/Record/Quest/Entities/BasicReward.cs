﻿using Xylia.Attribute.Component;

using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Table.XmlRecord;

namespace Xylia.Preview.Data.Record.QuestData
{
	[Signal("basic-reward")]
	public sealed class BasicReward : BaseNode
	{
		#region 字段
		public int Money;

		public int Exp;

		[Signal("production-id")] 
		public ProductionType ProductionId;

		[Signal("production-exp")]
		public short ProductionExp;

		[Signal("faction")]
		public Faction Faction;

		[Signal("faction-reputation")]
		public short FactionReputation;
		#endregion
	}
}