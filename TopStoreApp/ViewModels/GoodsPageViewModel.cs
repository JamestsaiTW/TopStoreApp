using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;

namespace TopStoreApp.ViewModels;

[QueryProperty(nameof(IsOrderQueryString), "isOrder")]
[QueryProperty(nameof(PersonIdQueryString), "personId")]
public partial class GoodsPageViewModel: BasePageViewModel
{
    [ObservableProperty]
    private ObservableCollection<Models.Product> _goods;

    [ObservableProperty]
    private bool _isOrder;

    public string IsOrderQueryString
    {
        set
        {
            IsOrder = bool.Parse(value);
        }
    }

    [ObservableProperty]
    private string _personId;

    public string PersonIdQueryString
    {
        set
        {
            PersonId = value;
        }
    }

    [RelayCommand]
    private async void Add()
    {
        //await Shell.Current.DisplayAlert("Alert", "ProductDetailPageNotImplement", "Cancel");
        await Shell.Current.GoToAsync("//Goods/ProductDetail?isEdit=true");
    }

    [RelayCommand]
    private async void Edit(Models.Product product)
    {
        //await Shell.Current.DisplayAlert("Alert", $"You select the {product.Name}, " +
        //                                          $"but ProductDetailPageNotImplement", "Cancel");
        
        //await Shell.Current.GoToAsync($"//Goods/ProductDetail?isEdit=false&productId={product.Id}");

        var routing = $"{Shell.Current.CurrentState.Location}/ProductDetail?isEdit=false&productId={product.Id}";
        routing = IsOrder ? $"{routing}&personId={PersonId}&isOrder=true" : routing;
        await Shell.Current.GoToAsync(routing);
    }

    [RelayCommand]
    private async void Delete(Models.Product product)
    {
        var isOk = await Shell.Current.DisplayAlert("警告", $"確定\"{product.Name}\"刪除?", "確定", "取消");
        if (isOk)
        {
            App.DataService.DeleteProduct(product);
            Goods = App.DataService.GetGoods();
        }
    }

    [RelayCommand]
    private async void MakeOrder(Models.Product product)
    {
        await Shell.Current.DisplayAlert("Alert", "MakeOrderPageNotImplement", "Cancel");
        //await Shell.Current.GoToAsync($"//Orders/MakeOrder?productId={product.Id}");
    }

    [RelayCommand]
    private async void Search(string keyword)
    {
        var results = App.DataService.GetGoods(keyword);
        if (results.Count != 0)
        {
            Goods = results;
            return;
        }
        await Shell.Current.DisplayAlert("通知", "查無相關貨品", "OK");
    }
}
