
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTreeView.Directory.ViewModel
{
    
    /// <summary>
    /// A basic command that runs an actions
    /// </summary>
    internal class RelayCommand : ICommand
    {

        #region PrivateMembers

        /// <summary>
        /// The actions to run
        /// </summary>
        private Action mAction;

        #endregion


        #region Public Events
        /// <summary>
        /// The events thats fired when the CanExecute(object) value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RelayCommand(Action action) 
        {
            mAction = action;
        }
        #endregion


        #region Command Methods
        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) 
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
        #endregion
    }
}
