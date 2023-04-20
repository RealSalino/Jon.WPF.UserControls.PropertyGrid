using PropertyGridApp.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PropertyGridApp.ViewModels
{
    public class PropertyGridControlViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PropertyEntry> PropertyEntries
        {
            get { return _propertyEntries; }
            set
            {
                _propertyEntries = value;
                OnPropertyChanged(nameof(PropertyEntries));
            }
        }

        public PropertyGridControlViewModel()
        {
            PropertyEntries = new ObservableCollection<PropertyEntry>
            {
                // Add your properties here
            };
        }
        private ObservableCollection<PropertyEntry> _propertyEntries;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}