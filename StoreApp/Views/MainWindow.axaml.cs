using Avalonia.Controls;
using Avalonia.Interactivity;

namespace StoreApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void OpenEditPanel(object sender, RoutedEventArgs args)
    {
        new EditPanel().Show();
    }
    
    public void OpenAddPanel(object sender, RoutedEventArgs args)
    {
        new AddPanel().Show();
    }
    
    public void OpenCartPanel(object sender, RoutedEventArgs args)
    {
        new CartPanel().Show();
    }
}