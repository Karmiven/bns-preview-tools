namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_Petition;
/// <summary>
/// ������
/// </summary>
public partial class Game_Petition_Scene : Window
{
	public Game_Petition_Scene()
	{
        DataContext = new Game_Petition_SceneViewModel();
		InitializeComponent();
	}
}