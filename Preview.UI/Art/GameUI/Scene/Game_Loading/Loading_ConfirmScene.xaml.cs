namespace Xylia.Preview.UI.Art.GameUI.Scene.Game_Loading;
/// <summary>
/// ��ͼ������ͼʱ��������Ϣ��
/// </summary>
public partial class Loading_ConfirmScene : Window
{
	public Loading_ConfirmScene()
	{
        DataContext = new Loading_ConfirmSceneViewModel();
		InitializeComponent();
	}
}