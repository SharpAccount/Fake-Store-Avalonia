using Avalonia.Media.Imaging;
using StoreApp.Helpers;

namespace StoreApp.Models;

public class Product : EventHelper
{

    private string name;
    private int price;
    private int quantity;
    private int maxQuantity;
    private Bitmap image;
    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public int Price
    {
        get => price;
        set
        {
            price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    public int Quantity
    {
        get => quantity;
        set
        {
            if (maxQuantity >= value)
            {
                quantity = value;
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
        maxQuantity = quantity;
        Quantity = quantity;
        Image = img;
    }
}