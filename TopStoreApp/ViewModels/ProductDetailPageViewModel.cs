using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TopStoreApp.ViewModels;

[QueryProperty(nameof(IsEditQueryString), "isEdit")]
[QueryProperty(nameof(ProductId), "productId")]
[QueryProperty(nameof(IsOrderQueryString), "isOrder")]
[QueryProperty(nameof(PersonIdQueryString), "personId")]
public partial class ProductDetailPageViewModel : BasePageViewModel
{
    [ObservableProperty]
    private Models.Product _editProduct;

    [ObservableProperty]
    private bool _isEdit;

    [ObservableProperty]
    private int _personId;
    public int PersonIdQueryString
    {
        set
        {
            PersonId = value;
        }
    }

    public string IsEditQueryString
    {
        set
        {
            IsEdit = bool.Parse(value);
        }
    }

    [ObservableProperty]
    private bool _isOrder;

    public string IsOrderQueryString
    {
        set
        {
            IsOrder = bool.Parse(value);
        }
    }

    public int ProductId
    {
        set
        {
            int productId = value;
            if (productId > 0)
                EditProduct = App.DataService.GetProduct(productId);
        }
    }

    public ProductDetailPageViewModel()
    {
        EditProduct = App.DataService.NewProduct();
    }

    [RelayCommand]
    private async void Save()
    {
        if (IsEdit)
        {
            var isValid = Utilities.ValidationHelper.IsValid(EditProduct, Shell.Current.CurrentPage);
            if (!isValid)
                return;

            App.DataService.SaveProduct(EditProduct);

            var isBack = await Shell.Current.DisplayAlert("通知", "儲存成功!", 
                                                           "返回物品項列表", "再檢視此筆資料");
            if (isBack)
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        IsEdit = !IsEdit;
    }

    [RelayCommand]
    private async void AddOrder()
    {
        //await Shell.Current.DisplayAlert("通知", "尚未實作", "OK");
        var routing = $"{Shell.Current.CurrentState.Location}/AddOrder?productId={EditProduct.Id}&personId={PersonId}";
        await Shell.Current.GoToAsync(routing);
    }
}
