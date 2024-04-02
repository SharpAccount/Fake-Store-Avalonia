using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using StoreApp.Models;
using StoreApp.ViewModels;

namespace StoreApp.Views;

public partial class MainWindow : Window
{
    private List<Window> windows = new List<Window>();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    public void OpenEditPanel(object sender, RoutedEventArgs args)
    {
        Product SelectedProduct = (Product)ProductList.SelectedItem;
        if (SelectedProduct is not null)
        {
            Window editPanel = new EditPanel(SelectedProduct);
            closeAll(editPanel);
            editPanel.Show();
            windows.Add(editPanel);
        }
    }
    
    public void OpenAddPanel(object sender, RoutedEventArgs args)
    {
        Window addPanel = new AddPanel();
        closeAll(addPanel);
        addPanel.Show();
        windows.Add(addPanel);
    }
    
    public void OpenCartPanel(object sender, RoutedEventArgs args)
    {
        dynamic added = ((ObservableCollection<Product>)ProductList.SelectedItems).Select(el => new Product(el.Name, el.Price, el.Quantity, el.Image));
        ObservableCollection<Product> copiedAdded = new ObservableCollection<Product>(added);
        Window cartPanel = new CartPanel(copiedAdded);
        closeAll(cartPanel);
        cartPanel.Show();
        windows.Add(cartPanel);
    }

    private void closeAll(Window toSave)
    {
        foreach (Window window in windows)
        {
            if (window != toSave)
            {
                window.Close();
            }
        }
    }
}