using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using StoreApp.Models;
using StoreApp;

namespace StoreApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static ObservableCollection<Product> _products = new();
    private static ObservableCollection<Product> _selected = new();
    private ObservableCollection<Product> _cart = new();

    private string _productName;
    private int _productPrice;
    private int _productQuantity;

    public void DeleteSelected()
    {
        for (int i = 0; i < Products.Count; i++)
        {
            foreach (var selectedProd in SelectedProducts.ToList())
            {
                if (Products[i].Name == selectedProd.Name)
                {
                    Products.RemoveAt(i);
                }
            }
            Console.WriteLine(i);
        }
    }

    public void AddToCart()
    {
        for (int i = 0; i < SelectedProducts.Count; i++)
        {
            if (!(Cart.Contains(SelectedProducts[i])))
            {
                Cart.Add(SelectedProducts[i]);
            }
        }
    }

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
    
    public ObservableCollection<Product> Cart
    {
        get => _cart;
        set => _cart = value;
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