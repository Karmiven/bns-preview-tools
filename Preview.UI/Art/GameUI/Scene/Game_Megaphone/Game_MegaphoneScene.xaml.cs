namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_Megaphone;
/// <summary>
/// ��ҫ����
/// </summary>
public partial class Game_MegaphoneScene : Window
{
	public Game_MegaphoneScene()
	{
        DataContext = new Game_MegaphoneSceneViewModel();
		InitializeComponent();
	}
}