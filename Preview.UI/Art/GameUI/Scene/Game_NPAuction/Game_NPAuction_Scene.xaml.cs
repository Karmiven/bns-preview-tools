namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_NPAuction;
/// <summary>
/// �����
/// </summary>
public partial class Game_NPAuction_Scene : Window
{
	public Game_NPAuction_Scene()
	{
        DataContext = new Game_NPAuction_SceneViewModel();
		InitializeComponent();
	}
}