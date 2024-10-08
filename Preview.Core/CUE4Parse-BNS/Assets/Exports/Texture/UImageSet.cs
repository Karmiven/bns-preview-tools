﻿using CUE4Parse.BNS.Conversion;
using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Exports.Texture;
using CUE4Parse.UE4.Objects.UObject;
using CUE4Parse_Conversion.Textures;
using SkiaSharp;

namespace CUE4Parse.BNS.Assets.Exports;
public sealed class UImageSet : USerializeObject
{
	#region Properties
	[UPROPERTY]
	public FPackageIndex Image;

	[UPROPERTY]
	public float U;

	[UPROPERTY]
	public float V;

	[UPROPERTY]
	public float UL;

	[UPROPERTY]
	public float VL;
	#endregion

	#region Methods
	public SKBitmap GetImage(SKColor tint = default) => Image?.Load<UTexture>()?.Decode()?.Clone((int)U, (int)V, (int)UL, (int)VL, tint);
	#endregion
}