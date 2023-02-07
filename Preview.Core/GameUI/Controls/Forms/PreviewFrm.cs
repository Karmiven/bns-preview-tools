using System.ComponentModel;
using System.Windows.Forms;

namespace Xylia.Preview.GameUI.Controls.Forms
{
	public class PreviewFrm : Form
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text { get => base.Text; set => base.Text = value; }


		public string Title
		{
			get => this.Text;
			set => this.Text = value;
		}
	}
}