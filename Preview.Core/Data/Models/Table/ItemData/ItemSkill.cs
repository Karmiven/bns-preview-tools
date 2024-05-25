﻿using Xylia.Preview.Data.Common.Abstractions;

namespace Xylia.Preview.Data.Models;
public sealed class ItemSkill : ModelElement, IHaveDesc
{
	#region Attributes
	public int SkillId { get; set; }

	public sbyte[] SkillVariationId { get; set; }

	public bool IncludeInheritanceSkill { get; set; }

	public Ref<Skill3> ItemSimSkill { get; set; }

	public Ref<Text> Name2 { get; set; }

	public Ref<Text> Description2 { get; set; }

	public Ref<Text> ItemSkillTooltip { get; set; }
	#endregion

	#region Methods
	public string Description
	{
		get
		{
			var text = Description2.GetText();
			return text is null ? null : string.Format("<font name=\"00008130.UI.Label_Green03_12\">{0}</font>", text);
		}
	}
	#endregion
}