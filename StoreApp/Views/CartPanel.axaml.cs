using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using StoreApp.Models;
using StoreApp.ViewModels;

namespace StoreApp.Views;

public partial class CartPanel : Window
{
    public CartPanel()
    {
        InitializeComponent();
        DataContext = new CartViewModel();
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