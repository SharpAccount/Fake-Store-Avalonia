using Avalonia.Media.Imaging;
using StoreApp.Helpers;

namespace StoreApp.Models;

public class Product : EventHelper
{

    private string _name;
    private int _price;
    private int _quantity;
    private int _maxQuantity;
    private Bitmap image;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public int Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_maxQuantity >= value)
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }

    public Bitmap Image
    {
        get => image;
        set
        {
            image = value;
            OnPropertyChanged(nameof(Image));
        } 
    }
    
    public Product(string name, int price, int quantity, Bitmap img)
    {
        Name = name;
        Price = price;
        _maxQuantity = quantity;
        Quantity = quantity;
        Image = img;
    }
}