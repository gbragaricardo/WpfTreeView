using PropertyChanged;
using System.ComponentModel;

namespace WpfTreeView
{

    /// <summary>
    /// Base ViewModel thats fire the property changed events as needed
    /// </summary>
    [ImplementPropertyChanged]
    internal class BaseViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// That event that is fired when any child propery changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}