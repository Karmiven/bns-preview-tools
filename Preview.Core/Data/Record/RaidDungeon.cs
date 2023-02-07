﻿using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class RaidDungeon : BaseRecord , Attraction
	{
		public Text Name2;


		[Signal("arena-minimap")]
		public string ArenaMinimap;

		[Signal("raid-dungeon-desc")]
		public Text RaidDungeonDesc;

		[Signal("ui-text-grade")]
		public byte UiTextGrade;




		#region 接口方法
		public string GetName() => this.Name2.GetText();

		public string GetDescribe() => this.RaidDungeonDesc.GetText();
		#endregion
	}
}