
namespace FileOrganizer.UI
{
	public partial class LabelStausBar : UserControl
	{
		public LabelStausBar()
		{
			InitializeComponent();
		}

		public string Title
		{
			set
			{
				label1.Text = value;
			}
		}
		public int MaxCount
		{
			set
			{
				progressBar1.Step = 1;
				progressBar1.Maximum = value;
			}
		}

		internal void PerformStep()
		{
			progressBar1.PerformStep();
		}
	}
}
