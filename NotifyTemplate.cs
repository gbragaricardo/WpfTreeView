using PropertyChanged;
using System.ComponentModel;
using System.Runtime.Remoting.Channels;

namespace WpfTreeView
{
    [ImplementPropertyChanged]
    internal class NotifyTemplate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test { get; set; } = "My Property";



    }
}
