namespace WpfTreeView
{
    /// <summary>
    /// Information about a directory item such as Drive, a folder or a file
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        public string  FullPath { get; set; }

        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);}} 
    }
}
