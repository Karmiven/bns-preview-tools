﻿using Xylia.Attribute.Component;

namespace Xylia.Preview.Common.Seq
{
	/// <summary>
	/// 循环组
	/// </summary>
	public enum RecycleGroup
	{
		None,

		[Signal("class")]
		Class,

		[Signal("item-1")]
		Item1,

		[Signal("item-2")]
		Item2,

		[Signal("class-2")]
		Class2,

		[Signal("db")]
		DB,

		[Signal("gadget")]
		Gadget,
	}
}