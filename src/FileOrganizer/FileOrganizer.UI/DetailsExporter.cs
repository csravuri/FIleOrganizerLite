using System.ComponentModel;

namespace FileOrganizer.UI
{
	internal class DetailsExporter
	{
		public void ExportData(FileInfo[] fileInfos, string path)
		{
			var exportData = fileInfos.Select(x => new CsvExportData
			{
				FileName = x.Name,
				FolderName = x.DirectoryName,
				FullPath = x.FullName,
				Extention = x.Extension,
				SizeInBytes = x.Length,
				Size = GetHumanReadableFileSize(x.Length),
				CreatedTime = x.CreationTime,
				AccessedTime = x.LastAccessTime,
				ModifiedTime = x.LastWriteTime,
			});

			SaveToCsv(exportData, path);
		}

		string GetHumanReadableFileSize(long lenInBytes)
		{
			string[] sizes = { "B", "KB", "MB", "GB", "TB" };
			int order = 0;
			while (lenInBytes >= 1024 && order < sizes.Length - 1)
			{
				order++;
				lenInBytes /= 1024;
			}

			return string.Format("{0:0.##} {1}", lenInBytes, sizes[order]);
		}

		void SaveToCsv<T>(IEnumerable<T> reportData, string path)
		{
			var lines = new List<string>();
			IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
			var header = string.Join(",", props.ToList().Select(x => x.Name));
			lines.Add(header);
			var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
			lines.AddRange(valueLines);
			File.WriteAllLines(path, lines.ToArray());
		}
	}


	class CsvExportData
	{
		public string FileName { get; set; }
		public string FolderName { get; set; }
		public string FullPath { get; set; }
		public string Extention { get; set; }
		public long SizeInBytes { get; set; }
		public string Size { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime ModifiedTime { get; set; }
		public DateTime AccessedTime { get; set; }
	}
}
