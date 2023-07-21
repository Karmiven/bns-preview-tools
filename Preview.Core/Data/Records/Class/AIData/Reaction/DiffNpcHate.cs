﻿using Xylia.Preview.Common.Attribute;
using Xylia.Preview.Common.Struct;

namespace Xylia.Preview.Data.Record.ReactionClass;

[Signal("diff-npc-hate")]
public sealed class DiffNpcHate : Reaction
{
	public Script_obj Opponent;

	public Script_obj Target;

	public int Amount;
}