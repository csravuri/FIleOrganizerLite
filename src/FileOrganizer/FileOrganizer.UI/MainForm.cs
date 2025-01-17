using System.ComponentModel;
using System.Security.Cryptography;

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

			foreach (var extention in files.Select(x => x.Extension.ToLower()).Distinct().OrderBy(x => x))
			{
				chkExtentionList.Items.Add(extention);
			}
		}

		FileAnalyzer Analyzer => fileAnalyzer ??= GetAnalyzer();
		private FileAnalyzer fileAnalyzer;

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

		private void btnNewGroup_Click(object sender, EventArgs e)
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

			var alreadyPresentFolder = lstGroupedList.Items.Cast<GroupFileList>().FirstOrDefault(x => x.FolderName == groupedFolder);
			if (alreadyPresentFolder is not null)
			{
				alreadyPresentFolder.Extentions.AddRange(selectedItems);
				var indx = lstGroupedList.Items.IndexOf(alreadyPresentFolder);
				lstGroupedList.Items.RemoveAt(indx);
				lstGroupedList.Items.Insert(indx, alreadyPresentFolder);
			}
			else
			{
				lstGroupedList.Items.Add(new GroupFileList
				{
					FolderName = groupedFolder,
					Extentions = selectedItems
				});
			}

			foreach (var item in selectedItems)
			{
				chkExtentionList.Items.Remove(item);
			}

			txtGroupFolder.Text = string.Empty;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (lstGroupedList.SelectedItem is GroupFileList selectedGroup)
			{
				var selectedItems = chkExtentionList.CheckedItems.Cast<string>().ToList();
				if (selectedItems.Count == 0)
				{
					ShowMessage("Select File Types");
					return;
				}

				selectedGroup.Extentions.AddRange(selectedItems);
				var indx = lstGroupedList.SelectedIndex;
				lstGroupedList.Items.RemoveAt(indx);
				lstGroupedList.Items.Insert(indx, selectedGroup);

				foreach (var item in selectedItems)
				{
					chkExtentionList.Items.Remove(item);
				}
			}
			else
			{
				ShowMessage("Select a Group");
			}
		}

		void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}

		private void btnMove_Click(object sender, EventArgs e)
		{
			TransferFiles(move: true);
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			TransferFiles();
		}

		void TransferFiles(bool move = false)
		{
			var fileInfos = Analyzer.GetFileDetails();
			if (fileInfos is null
				|| fileInfos.Length == 0)
			{
				ShowMessage("No files in Source folder");
				return;
			}

			var destinationFolder = txtDestinationFolder.Text;
			if (string.IsNullOrWhiteSpace(destinationFolder))
			{
				ShowMessage("Destination folder is required");
				return;
			}

			if (destinationFolder == txtSourceFolder.Text)
			{
				ShowMessage("Source and Destination cannot be same");
				return;
			}

			if (!Directory.Exists(destinationFolder))
			{
				Directory.CreateDirectory(destinationFolder);
			}

			foreach (var item in lstGroupedList.Items.Cast<GroupFileList>())
			{
				try
				{
					TransferFiles(move, item, fileInfos, destinationFolder);
				}
				catch (Exception ex)
				{
					ShowMessage(ex.Message);
					throw;
				}
			}

			lstGroupedList.Items.Clear();
		}

		private void TransferFiles(bool move, GroupFileList item, FileInfo[] fileInfos, string destinationFolder)
		{
			var filesToBeTransfered = fileInfos.Where(x => item.Extentions.Contains(x.Extension.ToLower())).ToArray();
			var progressBar = new LabelStausBar();
			progressBar.Title = item.FolderName;

			lpStatusLayout.Controls.Add(progressBar);

			using var worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += (s, e) =>
			{
				PerformTransfer(move, item, destinationFolder, filesToBeTransfered, worker);
			};
			worker.ProgressChanged += (s, e) => progressBar.Value = e.ProgressPercentage;
			worker.RunWorkerAsync();
		}

		private void PerformTransfer(bool move, GroupFileList item, string destinationFolder, FileInfo[] filesToBeTransfered, BackgroundWorker bgWorker)
		{
			var count = 0;
			foreach (var file in filesToBeTransfered)
			{
				count++;
				bgWorker.ReportProgress(count * 100 / filesToBeTransfered.Length);
				var destSubFolder = Path.Combine(destinationFolder, item.FolderName);
				Directory.CreateDirectory(destSubFolder);
				var finalPath = Path.Combine(destSubFolder, file.Name);

				var fileTransferRequired = true;
				var existingFileInfo = new FileInfo(finalPath);
				while (existingFileInfo.Exists)
				{
					if (HasSameHash(file.FullName, existingFileInfo.FullName))
					{
						fileTransferRequired = false;
						if (move)
						{
							file.Delete();
						}
						break;
					}
					finalPath = GetNewFilePath(existingFileInfo);
					existingFileInfo = new FileInfo(finalPath);
				}

				if (!fileTransferRequired)
				{
					continue;
				}

				if (move)
				{
					file.MoveTo(finalPath, false);
				}
				else
				{
					file.CopyTo(finalPath, false);
				}
			}
			bgWorker.ReportProgress(100);
		}

		string GetNewFilePath(FileInfo fileInfo)
		{
			var onlyFileName = Path.GetFileNameWithoutExtension(fileInfo.FullName);
			var files = Directory.GetFiles(fileInfo.DirectoryName, $"{onlyFileName}*{Path.GetExtension(fileInfo.Extension)}");
			return Path.Combine(fileInfo.DirectoryName, $"{onlyFileName} ({files.Length + 1}){fileInfo.Extension}");
		}

		bool HasSameHash(string newFile, string existingFile)
		{
			return GetHash(newFile) == GetHash(existingFile);
		}

		string GetHash(string fileName)
		{
			using (var md5 = MD5.Create())
			using (var stream = File.OpenRead(fileName))
			{
				return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
			}
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			if (Analyzer is null)
			{
				return;
			}

			var fileInfos = Analyzer.GetFileDetails();

			if (fileInfos == null || fileInfos.Length == 0)
			{
				ShowMessage("No files to export");
				return;
			}


			var dialog = new SaveFileDialog();
			dialog.Filter = "CSV File|*.csv";
			dialog.Title = "Export Data";
			dialog.ShowDialog();

			var fileName = dialog.FileName;
			if (!string.IsNullOrWhiteSpace(fileName))
			{
				var extention = Path.GetExtension(fileName);
				if (string.IsNullOrWhiteSpace(extention))
				{
					fileName += ".csv";
				}

				var exporter = new DetailsExporter();
				exporter.ExportData(fileInfos, fileName);
			}

		}
	}
}