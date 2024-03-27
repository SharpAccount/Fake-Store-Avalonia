using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using StoreApp.Models;
using StoreApp.ViewModels;

namespace StoreApp.Views;

public partial class CartPanel : Window
{
    public CartPanel(ObservableCollection<Product> _added)
    {
        InitializeComponent();
        DataContext = new CartViewModel(_added);
    }

    public void IncreaseQuantity(object sender, RoutedEventArgs args)
    {
        var button = (Button)sender;
        var product = (Product)button.DataContext;
        
        product.Quantity++;
    }
}