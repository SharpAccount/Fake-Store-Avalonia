using System.Collections.ObjectModel;
using Avalonia.Styling;
using StoreApp.Models;

namespace StoreApp;

public static class SessionContext
{
    private static ObservableCollection<Product> _cart = new();
    
    public static ObservableCollection<Product> Cart
    {
        get => _cart;
        set => _cart = value;
    }
}