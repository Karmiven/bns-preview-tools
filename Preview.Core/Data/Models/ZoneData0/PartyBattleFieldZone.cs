﻿using Xylia.Preview.Data.Common.Abstractions;
using Xylia.Preview.Data.Common.Attribute;
using Xylia.Preview.Data.Common.DataStruct;

namespace Xylia.Preview.Data.Models;
public sealed class PartyBattleFieldZone : Record, IAttraction
{
	public Ref<Text> ZoneName2;

	public Ref<Text> ZoneDesc;

	public string Text => this.ZoneName2.GetText();

	public string Describe => this.ZoneDesc.GetText();


	public enum PartyBattleFieldZoneType
	{
		None,

		[Name("occupation-war")]
		OccupationWar,

		[Name("capture-the-flag")]
		CaptureTheFlag,

		[Name("lead-the-ball")]
		LeadTheBall,
	}
}