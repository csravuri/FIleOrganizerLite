namespace FileOrganizer.UI
{
	public partial class MainForm : Form
	{


		public MainForm()
		{
			InitializeComponent();
		}

		private void btnAnalyse_Click(object sender, EventArgs e)
		{
			if (Analyzer is null)
			{
				return;
			}

			var fileInfos = Analyzer.GetFileDetails();
			FillExtenstionsList(fileInfos);
		}

		void FillExtenstionsList(FileInfo[] files)
		{
			chkExtentionList.Items.Clear();

			foreach (var extention in files.Select(x => x.Extension.ToLower()).Distinct())
			{
				chkExtentionList.Items.Add(extention);
			}
		}

		FileAnalyzer Analyzer => fileAnalyzer ?? GetAnalyzer();

		private FileAnalyzer GetAnalyzer()
		{
			var sourceFilePath = txtSourceFolder.Text;
			if (!Directory.Exists(sourceFilePath))
			{
				MessageBox.Show("Source folder not exists");
				return null;
			}

			return new FileAnalyzer(sourceFilePath);
		}

		private readonly FileAnalyzer fileAnalyzer;

	}
}