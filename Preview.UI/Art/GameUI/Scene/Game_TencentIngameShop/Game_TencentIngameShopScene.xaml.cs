namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_TencentIngameShop;
/// <summary>
/// �ɰ汾�̳�
/// </summary>
public partial class Game_TencentIngameShopScene : Window
{
	public Game_TencentIngameShopScene()
	{
        DataContext = new Game_TencentIngameShopSceneViewModel();
		InitializeComponent();
	}
}