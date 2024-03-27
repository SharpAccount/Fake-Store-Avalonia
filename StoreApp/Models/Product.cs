using System;
using System.ComponentModel;
using Avalonia.Automation;
using Tmds.DBus.Protocol;

namespace StoreApp.Models;

public class Product : INotifyPropertyChanged
{

    private string _name;
    private int _price;
    private int _quantity;
    private int _maxQuantity;
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
            if (_quantity > _maxQuantity)
            {
                _quantity = _maxQuantity;
                OnPropertyChanged(nameof(Quantity));
            }
            else
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }
    
    public Product(string name, int price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        _maxQuantity = quantity;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}