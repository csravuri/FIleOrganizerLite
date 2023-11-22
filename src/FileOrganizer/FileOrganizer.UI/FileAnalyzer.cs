namespace FileOrganizer.UI
{
	internal class FileAnalyzer
	{
		private readonly string sourcePath;

		public FileAnalyzer(string sourcePath)
		{
			this.sourcePath = sourcePath;
		}

		public FileInfo[] GetFileDetails()
		{
			var files = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories);

			if (files == null
				|| files.Length == 0)
			{
				return Array.Empty<FileInfo>();
			}

			return files.Select(f => new FileInfo(f)).ToArray();
		}
	}
}
