using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Construtor
        public MainWindow()
        {
            InitializeComponent();

        }
        #endregion

        #region OnLoaded

        /// <summary>
        /// When The Apllication First Opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Get Every Logical drive on the machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                // Create a new item for
                var item = new TreeViewItem()
                {
                    // Set the header 
                    Header = drive,

                    // And Full Path
                    Tag = drive

                };

                

                item.Items.Add(null);

                //Listen our for item expanded
                item.Expanded += Folder_Expanded;

                // Add this on main treeView
                FolderView.Items.Add(item);
            }
        }
        #endregion

        #region Folder Expanded
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {

            #region Initial Checks
            var item = sender as TreeViewItem;

            // If the item only contains dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }

            //Clear Dummy Data
            item.Items.Clear();

            // Get folder name
            var fullPath = item.Tag as string;

            #endregion

            #region Get Folders

            // Create a blank list for directories
            var directories = new List<string>();

            // Try and get directories from the folder
            try
            {

                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            

            }
            catch 
            { }

            // For each directory
            directories.ForEach(directoryPath =>
            {
                // Create directory Item
                var subItem = new TreeViewItem()
                {
                    // Set Header as folder name
                    Header = GetFileFolderName(directoryPath),
                    // And tag as full name
                    Tag = directoryPath
                };


                // Add dummy item so we can expand folder
                subItem.Items.Add(null);

                // Handle Expanding
                subItem.Expanded += Folder_Expanded;

                //Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion

            #region GetFiles

            // Create a blank list for files

            var files = new List<string>();

            // Try and get files from the folder
            try
            {

                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                {
                    files.AddRange(fs);
                }


            }
            catch
            { }

            // For each files
            files.ForEach(filePath =>
            {
                // Create files Item
                var subItem = new TreeViewItem()
                {
                    // Set Header as files name
                    Header = GetFileFolderName(filePath),
                    // And tag as full name
                    Tag = filePath
                };

                //Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion

        }
        #endregion

        #region GetFileFolderName
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');

            //Find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If we don't find a backslash, return the path itself
            if (lastIndex <= 0)
                return path;

            // return the name after the last backslash
            return path.Substring(lastIndex + 1);
        }
        #endregion        


    }
}
