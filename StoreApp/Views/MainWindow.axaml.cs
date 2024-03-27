using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using StoreApp.Models;
using StoreApp.ViewModels;

namespace StoreApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    public void OpenEditPanel(object sender, RoutedEventArgs args)
    {
        Product SelectedProduct = (Product)ProductList.SelectedItem;
        new EditPanel(SelectedProduct).Show();
    }
    
    public void OpenAddPanel(object sender, RoutedEventArgs args)
    {
        new AddPanel().Show();
    }
    
    public void OpenCartPanel(object sender, RoutedEventArgs args)
    {
        dynamic added = ((ObservableCollection<Product>)ProductList.SelectedItems).Select(el => new Product(el.Name, el.Price, el.Quantity));
        ObservableCollection<Product> copiedAdded = new ObservableCollection<Product>(added);
        new CartPanel(copiedAdded).Show();
    }
}