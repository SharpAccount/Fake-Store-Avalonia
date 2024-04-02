using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using StoreApp.Helpers;
using StoreApp.Models;
using StoreApp.Views;

namespace StoreApp.ViewModels;

public class AddPanelViewModel : MainWindowViewModel
{
    private Bitmap currentImage = ImageHelper.LoadFromResource(new Uri("avares://StoreApp/Assets/WIN_20230512_16_01_07_Pro.jpg")); 

    public Bitmap Image
    {
        get => currentImage;
        set
        {
            currentImage = value;
        } 
    }
    
    public void AddProduct()
    {
        Product prod = new Product(ProductName, ProductPrice, ProductQuantity, Image);
        if (IsElementInCollectionOrNull(prod.Name) == false)
        {
            Products.Add(prod);
        }
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

    public async void SetImage()
    {
        OpenFileDialog explorer = new OpenFileDialog();
        explorer.AllowMultiple = false;
        FileDialogFilter filter = new FileDialogFilter();
        filter.Name = "ток картинки";
        filter.Extensions.AddRange(new List<string>() {"jpg", "png", "jpeg"});
        explorer.Filters.Add(filter);

        string[] result = await explorer.ShowAsync(new AddPanel());
        
        if (result.Length > 0)
        {
            string imagePath = result[0];
            Bitmap imageSource = new Bitmap(imagePath);
            Image = imageSource;
        }
    }
}