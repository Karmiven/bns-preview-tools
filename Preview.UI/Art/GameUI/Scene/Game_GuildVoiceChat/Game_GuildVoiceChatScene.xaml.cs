namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_GuildVoiceChat;
/// <summary>
/// ��������
/// </summary>
public partial class Game_GuildVoiceChatScene : Window
{
	public Game_GuildVoiceChatScene()
	{
        DataContext = new Game_GuildVoiceChatSceneViewModel();
		InitializeComponent();
	}
}