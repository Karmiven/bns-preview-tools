using System;
using System.Windows.Forms;

using Xylia.Preview.GameUI.Scene.Game_Auction;

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

			//Application.Run(new Game_AuctionScene());
			Application.Run(new DebugFrm());
		}
	}
}