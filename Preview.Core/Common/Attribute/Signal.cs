using System.ComponentModel;

namespace Xylia.Preview.Common.Attribute
{
	/// <summary>
	/// 标记
	/// </summary>
	public sealed class Signal : DescriptionAttribute
	{
		public Signal(string Description) : base(Description) { }
	}
}