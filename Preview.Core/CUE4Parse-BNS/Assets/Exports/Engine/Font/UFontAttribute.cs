﻿using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Assets.Readers;

namespace CUE4Parse.BNS.Assets.Exports;
public class UFontAttribute : USerializeObject
{
	public bool Italic;
	public bool Shadow;
	public bool Outline;
	public bool Strokeout;
	public bool Underline;

	public override void Deserialize(FAssetArchive Ar, long validPos)
	{
		base.Deserialize(Ar, validPos);

		if (TryGetValue(out FStructFallback FontAttributes, "FontAttributes"))
		{
			Italic = FontAttributes.GetOrDefault<bool>("Italic");
			Shadow = FontAttributes.GetOrDefault<bool>("Shadow");
			Outline = FontAttributes.GetOrDefault<bool>("Outline");
			Strokeout = FontAttributes.GetOrDefault<bool>("Strokeout");
			Underline = FontAttributes.GetOrDefault<bool>("Underline");
		}
	}
}