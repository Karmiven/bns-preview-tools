namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_InstantNotification;
/// <summary>
/// ������ʾ����
/// </summary>
public partial class Game_InstantNotificationScene : Window
{
	public Game_InstantNotificationScene()
	{
        DataContext = new Game_InstantNotificationSceneViewModel();
		InitializeComponent();
	}
}