using System.ComponentModel;

namespace StoreApp.Helpers;

public class EventHelper: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}