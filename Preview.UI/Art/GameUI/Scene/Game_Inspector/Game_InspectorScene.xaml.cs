namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_Inspector;
/// <summary>
/// ��Ʒ��Ϣ��ʾ����
/// </summary>
public partial class Game_InspectorScene : Window
{
	public Game_InspectorScene()
	{
        DataContext = new Game_InspectorSceneViewModel();
		InitializeComponent();
	}
}