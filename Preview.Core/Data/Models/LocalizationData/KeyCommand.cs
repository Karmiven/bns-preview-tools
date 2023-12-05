﻿using SkiaSharp;

using Xylia.Preview.Data.Common.Attribute;
using Xylia.Preview.Data.Common.Seq;
using Xylia.Preview.Data.Helpers;

namespace Xylia.Preview.Data.Models;
public sealed class KeyCommand : Record
{
	#region Field
	public KeyCommandSeq Command;

	[Name("default-keycap")]
	public string DefaultKeycap;
	#endregion

	#region Methods
	private KeyCap[] GetKeyCaps()
	{
		var result = new List<KeyCap>();

		if (this.DefaultKeycap != null)
		{
			//逗号分隔多个快捷键, 实际未支持处理
			foreach (var o in this.DefaultKeycap.Split(','))
			{
				if (string.IsNullOrWhiteSpace(o) || o == "none") continue;

				if (o.StartsWith("^"))
				{
					result.Add(KeyCap.Cast(KeyCode.Control));
					result.Add(KeyCap.Cast(o[1..]));
				}
				else if (o.StartsWith("~"))
				{
					result.Add(KeyCap.Cast(KeyCode.Alt));
					result.Add(KeyCap.Cast(o[1..]));
				}
				else result.Add(KeyCap.Cast(o));
			}
		}

		return result.ToArray();
	}

	private KeyCap GetKey(int Index) => this.GetKeyCaps().Length >= Index + 1 ? this.GetKeyCaps()[Index] : null;
	public KeyCap Key1 => GetKey(0);
	public KeyCap Key2 => GetKey(1);


	public string GetImage() => this.Key1?.Image;

	public SKBitmap GetIcon() => this.Key1?.Icon;

	public static KeyCommand Cast(KeyCommandSeq KeyCommand) => FileCache.Data.KeyCommand.FirstOrDefault(o => o.Command == KeyCommand);
	#endregion
}