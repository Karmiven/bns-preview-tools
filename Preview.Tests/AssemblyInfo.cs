using System;
using System.Windows.Forms;

namespace Xylia.Preview.Tests
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.SetCompatibleTextRenderingDefault(false);

			Application.Run(new DebugFrm());
		}
	}
}