using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfTreeView.Directory.ViewModel;

namespace WpfTreeView
{
    /// <summary>
    /// A ViewModel for each DirectoryItem
    /// </summary>
    internal class DirectoryItemViewModel : BaseViewModel
    {

        #region PublicProperties
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The Full path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// a list of all children contained inside this item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children{ get; set; }

        /// <summary>
        /// Indicates if item can be expanded
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        /// <summary>
        /// Indicates if the current item is expanded or not
        /// </summary>
        public bool IsExpanded 
        {
            get
            {
                return this.Children?.Count(f => f!= null) > 0;
            }
            set
            {
                // If the ui tell us to expand
                if (value == true)

                    // Find all children
                    Expand();

                // If the ui tells us to close
                else
                    this.ClearChildren();
            }
        }
        #endregion

        #region Public Commands
        /// <summary>
        /// The command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            //Create commands
            this.ExpandCommand = new RelayCommand(Expand);

            //Set Path and type

            this.FullPath = fullPath;
            this.Type = type;

            //Setup the children as needed
            this.ClearChildren();

        }


        #region HelperMethods

        /// <summary>
        /// Remove all childrens from the list, addin a dummy item to show the expand icon if required
        /// </summary>
        private void ClearChildren()
        {
            //Clear items
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            //Show the expand arrow if we are not a file 
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }
        #endregion

        /// <summary>
        /// Expand this directory and find all childrens
        /// </summary>
        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;
            //Find all children
            this.Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(this.FullPath).
                            Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
       

    }
}
