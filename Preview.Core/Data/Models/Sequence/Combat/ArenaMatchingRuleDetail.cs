﻿using Xylia.Preview.Common.Attributes;

namespace Xylia.Preview.Data.Models.Sequence.Combat;
public enum ArenaMatchingRuleDetail
{
    None,

    Normal,

    [Name("guild combat")]
    GuildCombat,

    [Name("sparring")]
    Sparring,

    [Name("unrated match")]
    UnratedMatch,

    [Name("championship")]
    Championship,

    [Name("ingame championship")]
    IngameChampionship,

    [Name("random party battle field match")]
    RandomPartyBattleFieldMatch,

    [Name("battle royal field party mode")]
    BattleRoyalFieldPartyMode,

    [Name("battle royal field championship")]
    BattleRoyalFieldChampionship,

    [Name("battle royal field party mode championship")]
    BattleRoyalFieldPartyModeChampionship,
}