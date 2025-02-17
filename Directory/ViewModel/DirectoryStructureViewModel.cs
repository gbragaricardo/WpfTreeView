using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTreeView
{

    /// <summary>
    /// The view model for the applications main Directory view
    /// </summary>
    internal class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties

        // A list of all directories on the machine 
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion

        #region constructor
        public DirectoryStructureViewModel()
        {
            //Get logical drives
            var children = DirectoryStructure.GetLogicalDrives();

            // Create the view models from the data
            this.Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
        


        #endregion

    }
}
