using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StoreApp.ViewModels;

namespace StoreApp.Views;

public partial class AddPanel : Window
{
    public AddPanel()
    {
        InitializeComponent();
        DataContext = new AddPanelViewModel();
    }
}