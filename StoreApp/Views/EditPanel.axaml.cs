﻿using Avalonia.Controls;
using StoreApp.Models;
using StoreApp.ViewModels;

namespace StoreApp.Views;

public partial class EditPanel : Window
{
    public EditPanel(Product product)
    {
        InitializeComponent();
        DataContext = new EditPanelViewModel(product);
        ProductName.Text = product.Name;
        ProductCost.Text = product.Price.ToString();
        ProductQuantity.Text = product.Quantity.ToString();
    }
    
    public EditPanel(){}
}