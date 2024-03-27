using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StoreApp.Models;

namespace StoreApp.ViewModels;

public class AddPanelViewModel: MainWindowViewModel
{
    public void AddProduct()
    {
        Product prod = new Product(ProductName, ProductPrice, ProductQuantity);
        if (IsElementInCollection(prod.Name) == false)
        {
            Products.Add(prod);
        }
    }
    
    private bool IsElementInCollection(string name)
    {
        foreach (Product prod in Products)
        {
            if (prod.Name == name)
            {
                return true;
            }
        }
        return false;
    }
}