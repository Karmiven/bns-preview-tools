namespace Xylia.Preview.UI.Art.GameUI.Scene.Lobby_CreateCharacter;
/// <summary>
/// ������ɫʱ ѡ��ְҵ
/// </summary>
public partial class Lobby_CreateCharacterScene : Window
{
	public Lobby_CreateCharacterScene()
	{
        DataContext = new Lobby_CreateCharacterSceneViewModel();
		InitializeComponent();
	}
}