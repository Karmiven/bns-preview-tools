namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_NativeCharacterInfo;
/// <summary>
/// ������Ϣ���ɰ汾���ɿ�������
/// </summary>
public partial class Game_NativeCharacterInfoScene : Window
{
	public Game_NativeCharacterInfoScene()
	{
        DataContext = new Game_NativeCharacterInfoSceneViewModel();
		InitializeComponent();
	}
}