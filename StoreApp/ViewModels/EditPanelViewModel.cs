using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using StoreApp.Models;
using StoreApp.Views;

namespace StoreApp.ViewModels;

public class EditPanelViewModel: MainWindowViewModel
{
    private int id;
    
    private string originalName;
    private int originalQuantity;
    private int originalPrice;
    private Bitmap originalImage;

    private string nameToChange;
    private Bitmap imageToChange;

    public string NameToChange
    {
        get => nameToChange;
        set => nameToChange = value;
    }

    public Bitmap ImageToChange
    {
        get => imageToChange;
        set => imageToChange = value;
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
            Products[id].Image = ImageToChange;
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
    
    public async void ChangeImage()
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
            ImageToChange = imageSource;
        }
    }
}