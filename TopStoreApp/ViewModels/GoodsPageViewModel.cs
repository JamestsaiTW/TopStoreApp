using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace TopStoreApp.ViewModels;

public partial class GoodsPageViewModel: BasePageViewModel
{
    [ObservableProperty]
    private ObservableCollection<Models.Product> _goods;

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
        await Shell.Current.GoToAsync($"//Goods/ProductDetail?isEdit=false&personId={product.Id}");
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
