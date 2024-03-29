using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using StoreApp.Models;

namespace StoreApp.ViewModels;

public class CartViewModel: MainWindowViewModel, INotifyPropertyChanged
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
        set
        {
            total = value;
            OnPropertyChanged(nameof(Total));
        } 
    }

    public int CurrentQuantity
    {
        get => currentQuantity;
        set => currentQuantity = value;
    }

    internal void setTotal()
    {
        int sum = 0;
        foreach (Product prod in addedCurrent)
        {
            sum += prod.Price * prod.Quantity;
        }
        Total = sum.ToString();
    }

    internal void DeleteSelected(Product selected)
    {
        AddedCurrent.Remove(selected);
        setTotal();
    }

    internal void ClearSelected()
    {
        foreach (Product bought in addedCurrent)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (bought.Name == Products[i].Name)
                {
                    if (bought.Quantity != Products[i].Quantity)
                    {
                        Products[i].Quantity -= bought.Quantity;
                    }
                    else
                    {
                        Products.RemoveAt(i);
                    }
                }
            }
        }
        AddedCurrent.Clear();
        setTotal();
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}