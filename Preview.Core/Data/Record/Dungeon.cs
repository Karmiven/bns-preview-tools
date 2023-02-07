﻿using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	[AliasRecord]
	public sealed class Dungeon : BaseRecord , Attraction
	{
		[Signal("ui-text-grade")]
		public byte UiTextGrade;

		[Signal("dungeon-name2")]
		public Text DungeonName2;

		[Signal("dungeon-desc")]
		public Text DungeonDesc;



		#region 接口字段
		public string GetName() => this.DungeonName2.GetText();

		public string GetDescribe() => this.DungeonDesc.GetText();
		#endregion
	}
}