using System.Collections.ObjectModel;
using System.Reactive.Linq;
using StoreApp.Models;

namespace StoreApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ObservableCollection<Product> _products = new();

    private string? _productName;
    private int _productPrice;
    private int _productQuantity;

    public ObservableCollection<Product> Products
    {
        get => _products;
        set => _products = value;
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