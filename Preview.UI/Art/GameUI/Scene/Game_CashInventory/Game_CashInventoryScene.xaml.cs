namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_CashInventory;
/// <summary>
/// ���Ѱ���
/// </summary>
public partial class Game_CashInventoryScene : Window
{
	public Game_CashInventoryScene()
	{
        DataContext = new Game_CashInventorySceneViewModel();
		InitializeComponent();
	}
}