namespace Xylia.Preview.UI.Art.GameUI.Scene.Lobby_Title;
/// <summary>
/// �û�Э��
/// </summary>
public partial class Lobby_NPOptionScene : Window
{
	public Lobby_NPOptionScene()
	{
        DataContext = new Lobby_NPOptionSceneViewModel();
		InitializeComponent();
	}
}