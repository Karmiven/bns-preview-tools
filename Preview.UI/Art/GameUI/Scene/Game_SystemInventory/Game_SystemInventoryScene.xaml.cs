namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_SystemInventory;
/// <summary>
/// ������ & ��ʧ��Ʒ
/// </summary>
public partial class Game_SystemInventoryScene : Window
{
	public Game_SystemInventoryScene()
	{
        DataContext = new Game_SystemInventorySceneViewModel();
		InitializeComponent();
	}
}