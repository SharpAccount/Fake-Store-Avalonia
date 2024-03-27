using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using StoreApp.Models;

namespace StoreApp.ViewModels;

public class EditPanelViewModel: MainWindowViewModel
{
    private int id;
    
    private string originalName;
    private int originalQuantity;
    private int originalPrice;
    
    public EditPanelViewModel(Product product)
    {
        originalName = product.Name;
        originalPrice = product.Price;
        originalQuantity = product.Quantity;

        id = FindIndex(originalName);
    }
    public void SetProductFields()
    {
        Products[id].Name = ProductName;
        Products[id].Price = ProductPrice;
        Products[id].Quantity = ProductQuantity;
    }

    public int FindIndex(string nameToFind)
    {
        for (int i = 0; i < Products.Count(); i++)
        {
            if (Products[i].Name == nameToFind)
            {
                return i;
            }
        }
        return -1;
    }
}