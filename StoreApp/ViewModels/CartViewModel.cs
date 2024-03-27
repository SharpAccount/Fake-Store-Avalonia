using System;
using System.Collections.ObjectModel;
using StoreApp.Models;

namespace StoreApp.ViewModels;

public class CartViewModel: MainWindowViewModel
{
    private ObservableCollection<Product> added = new ();
    private ObservableCollection<Product> addedCurrent = new ();
    private string total;
    private int currentQuantity = 0;

    public CartViewModel(ObservableCollection<Product> _added)
    {
        added = _added;
        addedCurrent = _added;
        foreach (var prod in addedCurrent)
        {
            prod.Quantity = 1;
        }
        setTotal();
    }

    public ObservableCollection<Product> AddedCurrent
    {
        get => addedCurrent;
        set => addedCurrent = value;
    }

    public string Total
    {
        get => total;
        set => total = value;
    }

    public int CurrentQuantity
    {
        get => currentQuantity;
        set => currentQuantity = value;
    }

    private void setTotal()
    {
        int sum = 0;
        foreach (Product prod in addedCurrent)
        {
            sum += prod.Price * prod.Quantity;
        }
        Total = sum.ToString();
    }

    internal void ClearSelected()
    {
        try
        {
            AddedCurrent.Clear();
            setTotal();
        }
        catch (Exception ex)
        {
            Console.WriteLine(AddedCurrent);
            throw new Exception("some shit happens sometimes");
        }
    }
}