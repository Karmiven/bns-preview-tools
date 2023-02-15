﻿
using System.Collections.Generic;

using Xylia.Attribute.Component;


namespace Xylia.Preview.Data.Record.QuestData.Case
{
	/// <summary>
	/// 拾取掉落物
	/// </summary>
	public sealed class Loot : CaseBase
	{
		public string Object2;

		[Signal("multi-object-1")] public string MultiObject1;
		[Signal("multi-object-2")] public string MultiObject2;
		[Signal("multi-object-3")] public string MultiObject3;
		[Signal("multi-object-4")] public string MultiObject4;
		[Signal("multi-object-5")] public string MultiObject5;
		[Signal("multi-object-6")] public string MultiObject6;
		[Signal("multi-object-7")] public string MultiObject7;
		[Signal("multi-object-8")] public string MultiObject8;
		[Signal("multi-object-9")] public string MultiObject9;
		[Signal("multi-object-10")] public string MultiObject10;
		[Signal("multi-object-11")] public string MultiObject11;
		[Signal("multi-object-12")] public string MultiObject12;
		[Signal("multi-object-13")] public string MultiObject13;
		[Signal("multi-object-14")] public string MultiObject14;
		[Signal("multi-object-15")] public string MultiObject15;
		[Signal("multi-object-16")] public string MultiObject16;


		[Signal("quest-symbol-drop-prob")]
		public byte QuestSymbolDropProb;

		[Signal("loot-item")]
		public Item LootItem;

		[Signal("env-looting")]
		public string EnvLooting;

		/// <summary>
		/// VirtualItem
		/// </summary>
		[Side(Side.Type.Client)]
		public string Looting;




		#region 方法
		public override List<string> AttractionObject => new()
		{
			Object2,

			MultiObject1,
			MultiObject2,
			MultiObject3,
			MultiObject4,
			MultiObject5,
			MultiObject6,
			MultiObject7,
			MultiObject8,
			MultiObject9,
			MultiObject10,
			MultiObject11,
			MultiObject12,
			MultiObject13,
			MultiObject14,
			MultiObject15,
			MultiObject16,
		};
		#endregion
	}
}