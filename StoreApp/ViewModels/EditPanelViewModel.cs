using System.Collections.Generic;
using System.Linq;
using StoreApp.Models;

namespace StoreApp.ViewModels;

public class EditPanelViewModel: MainWindowViewModel
{
    private int id;
    
    private string originalName;
    private int originalQuantity;
    private int originalPrice;

    private string nameToChange;

    public string NameToChange
    {
        get => nameToChange;
        set => nameToChange = value;
    }
    
    public EditPanelViewModel(Product product)
    {
        originalName = product.Name;
        originalPrice = product.Price;
        originalQuantity = product.Quantity;

        id = FindIndex(originalName);
    }
    public void SetProductFields()
    {
        if (IsElementInCollectionOrNull(NameToChange) == false)
        {
            Products[id].Name = NameToChange;
            Products[id].Price = ProductPrice;
            Products[id].Quantity = ProductQuantity;
        }
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
    
    private bool IsElementInCollectionOrNull(string name)
    {
        if (name != "")
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
        return true;
    }
}