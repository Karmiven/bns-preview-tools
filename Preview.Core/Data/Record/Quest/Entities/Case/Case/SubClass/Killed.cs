﻿using System.Collections.Generic;

using Xylia.Preview.Common.Attribute;
using Xylia.Preview.Common.Seq;
using Xylia.Preview.Data.Record.QuestData.Enums;

namespace Xylia.Preview.Data.Record.QuestData.Case
{
	public sealed class Killed : CaseBase
	{
		[Signal("specify-object-type")]
		public SpecifyObjectType SpecifyObjectType;

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

		[Signal("killed-difficulty-type")]
		public DifficultyType KilledDifficultyType;

		public Skill3 Skill3;


		#region Functions
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