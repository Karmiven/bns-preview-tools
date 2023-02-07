using HZH_Controls;

namespace Xylia.Preview
{
	public static class Program
	{
		static bool? _designMode;
		public static bool IsDesignMode => _designMode ?? (_designMode = ControlHelper.IsDesignMode()).Value;
	}
}