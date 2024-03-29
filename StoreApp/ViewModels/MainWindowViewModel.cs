using System.Collections.ObjectModel;
using StoreApp.Models;

namespace StoreApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static ObservableCollection<Product> _products = new();
    private static ObservableCollection<Product> _selected = new();

    private string _productName;
    private int _productPrice;
    private int _productQuantity;

    public static ObservableCollection<Product> Products
    {
        get => _products;
        set => _products = value;
    }
    
    public static ObservableCollection<Product> SelectedProducts
    {
        get => _selected;
        set => _selected = value;
    }

    public string ProductName
    {
        get => _productName;
        set => _productName = value;
    }
    
    public int ProductQuantity
    {
        get => _productQuantity;
        set => _productQuantity = value;
    }
    
    public int ProductPrice
    {
        get => _productPrice;
        set => _productPrice = value;
    }
}