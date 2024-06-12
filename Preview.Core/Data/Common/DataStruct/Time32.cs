﻿using Xylia.Preview.Data.Engine.DatData;

namespace Xylia.Preview.Data.Common.DataStruct;
/// <summary>
///  Represents an instant in time
/// </summary>
public struct Time32(int Ticks)	 /*: ITime*/
{
	public int Ticks = Ticks;

	public static Time32 Parse(string input, EPublisher publisher)
	{
		throw new NotImplementedException();
	}
}