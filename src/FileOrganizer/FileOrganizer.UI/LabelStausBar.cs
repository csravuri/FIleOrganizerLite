
namespace FileOrganizer.UI
{
	public partial class LabelStausBar : UserControl
	{
		public LabelStausBar()
		{
			InitializeComponent();
			progressBar1.Maximum = 100;
		}

		public string Title
		{
			set
			{
				label1.Text = value;
			}
		}
		public int Value
		{
			set
			{
				progressBar1.Value = value;
			}
		}
	}
}
