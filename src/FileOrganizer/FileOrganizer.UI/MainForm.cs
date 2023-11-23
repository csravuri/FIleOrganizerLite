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
				ShowMessage("Source folder not exists");
				return null;
			}

			return new FileAnalyzer(sourceFilePath);
		}

		private readonly FileAnalyzer fileAnalyzer;

		private void btnGroup_Click(object sender, EventArgs e)
		{
			var selectedItems = chkExtentionList.CheckedItems.Cast<string>().ToList();
			if (selectedItems.Count == 0)
			{
				ShowMessage("Select File Types");
				return;
			}

			var groupedFolder = txtGroupFolder.Text;
			if (string.IsNullOrWhiteSpace(groupedFolder))
			{
				ShowMessage("Enter Group folder");
				return;
			}

			lstGroupedList.Items.Add(new GroupFileList
			{
				FolderName = groupedFolder,
				Extentions = selectedItems
			});

			foreach (var item in selectedItems)
			{
				chkExtentionList.Items.Remove(item);
			}

			txtGroupFolder.Text = string.Empty;
		}

		void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}
	}
}