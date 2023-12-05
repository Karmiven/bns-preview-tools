﻿using Xylia.Preview.Data.Common.Attribute;
using Xylia.Preview.Data.Common.DataStruct;
using Xylia.Preview.Data.Common.Seq;

namespace Xylia.Preview.Data.Models;
public sealed class ItemCombat : Record
{
	[Name("job-style")]
	public JobStyleSeq JobStyle;

	[Name("item-skill"), Repeat(16)]
	public Ref<ItemSkill>[] ItemSkill;

	[Name("item-skill-second"), Repeat(16)]
	public Ref<ItemSkill>[] ItemSkillSecond;

	[Name("item-skill-third"), Repeat(16)]
	public Ref<ItemSkill>[] ItemSkillThird;

	[Name("skill-modify-info-group")]
	public Ref<SkillModifyInfoGroup> SkillModifyInfoGroup;



	public override string ToString()
	{
		var ItemSkills = new List<Ref<ItemSkill>>();
		ItemSkills.AddRange(ItemSkill);
		ItemSkills.AddRange(ItemSkillSecond);
		ItemSkills.AddRange(ItemSkillThird);

		return ItemSkills.Select(@ref => @ref.Instance)
			.Where(record => record?.Description2 != null)
			.Aggregate(SkillModifyInfoGroup.Instance?.ToString(), (sum, now) => sum + "<br/>" + now.Description2.GetText());
	}
}