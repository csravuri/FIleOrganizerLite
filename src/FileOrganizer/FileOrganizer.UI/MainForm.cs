namespace FileOrganizer.UI
{
	public partial class MainForm : Form
	{
		private FileAnalyzer fileAnalyzer;

		public MainForm()
		{
			InitializeComponent();
		}

		private void btnAnalyse_Click(object sender, EventArgs e)
		{
			var sourceFilePath = txtSourceFolder.Text;
			if (!Directory.Exists(sourceFilePath))
			{
				MessageBox.Show("Source folder not exists");
				return;
			}

			fileAnalyzer = new FileAnalyzer(sourceFilePath);
			var fileInfos = fileAnalyzer.GetFileDetails();
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
	}
}