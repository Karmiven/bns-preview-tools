namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_PartySerch;
/// <summary>
/// ��������
/// </summary>
public partial class Game_PartySerchNotificationScene : Window
{
	public Game_PartySerchNotificationScene()
	{
        DataContext = new Game_PartySerchNotificationSceneViewModel();
		InitializeComponent();
	}
}