namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_PCPicker;
/// <summary>
/// ���������
/// </summary>
public partial class Game_PCPickerScene : Window
{
	public Game_PCPickerScene()
	{
        DataContext = new Game_PCPickerSceneViewModel();
		InitializeComponent();
	}
}