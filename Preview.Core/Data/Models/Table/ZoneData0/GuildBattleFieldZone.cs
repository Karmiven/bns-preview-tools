﻿namespace Xylia.Preview.Data.Models;
public sealed class GuildBattleFieldZone : ModelElement, IAttration
{
	#region IAttraction
	public string Name => this.Attributes["guild-battle-field-zone-name2"].GetText();
	public string Description => this.Attributes["guild-battle-field-zone-desc"].GetText();
	#endregion
}