namespace FileOrganizer.UI
{
	internal class GroupFileList
	{
		public string FolderName { get; set; }
		public List<string> Extentions { get; set; }

		public override string ToString()
		{
			return $"{FolderName} => {string.Join(",", Extentions)}";
		}
	}
}
