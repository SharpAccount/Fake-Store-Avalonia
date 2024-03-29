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

        var viewModel = (CartViewModel)this.DataContext;
        product.Quantity++;
        viewModel.setTotal();
    }
    
    public void DecreaseQuantity(object sender, RoutedEventArgs args)
    {
        var button = (Button)sender;
        var product = (Product)button.DataContext;
        if (product.Quantity > 1)
        {
            product.Quantity--;
            var viewModel = (CartViewModel)this.DataContext;
            viewModel.setTotal();
        }
    }

    public void DeleteSelected(object sender, RoutedEventArgs args)
    {
        var product = (Product)Cart.SelectedItem;
        var viewModel = (CartViewModel)this.DataContext;
        viewModel.DeleteSelected(product);
    }
}