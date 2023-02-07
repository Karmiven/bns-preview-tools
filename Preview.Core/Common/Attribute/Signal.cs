using System.ComponentModel;

namespace Xylia.Attribute.Component
{
	/// <summary>
	/// 标记
	/// </summary>
	public sealed class Signal : DescriptionAttribute
	{
		public Signal(string Description) : base(Description) { }
	}
}
