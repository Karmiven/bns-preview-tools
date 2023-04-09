using System.Drawing;

using Xylia.Preview.Common.Attribute;
using Xylia.Extension;
using Xylia.Preview.Common.Seq;

namespace Xylia.Preview.Data.Record
{
	public sealed class KeyCap : BaseRecord
	{
		#region Fields	
		[Signal("key-code")]
		public KeyCode KeyCode;

		public string Name;

		[Signal("short-name")]
		public string ShortName;

		[Signal("scroll-imageset")]
		public string ScrollImageset;

		[Signal("scroll-imageset-scale")]
		public float ScrollImagesetScale;
		#endregion


		#region Functions
		public Bitmap Icon => this.Attributes["icon"].GetIcon();

		public string Image => this.Attributes["image"].GetText();


		public static KeyCap GetKeyCap(KeyCode KeyCode) => FileCache.Data.KeyCap[(short)KeyCode];

		public static KeyCap GetKeyCap(string o) => GetKeyCap(GetKeyCode(o));

		public static KeyCode GetKeyCode(string o)
		{
			if (o == "SPACEBAR") return KeyCode.Space;

			return o.ToEnum<KeyCode>();
		}
		#endregion
	}
}