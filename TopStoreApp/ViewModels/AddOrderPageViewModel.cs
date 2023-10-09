using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TopStoreApp.Models;

namespace TopStoreApp.ViewModels;

[QueryProperty(nameof(ProductId), "productId")]
[QueryProperty(nameof(PersonId), "personId")]
[QueryProperty(nameof(OrderId), "orderId")]
public partial class AddOrderPageViewModel : BasePageViewModel
{

    [ObservableProperty]
    private Product _currentProduct;
    public int ProductId
    {
        set
        {
            int productId = value;
            if (productId > 0)
                CurrentProduct = App.DataService.GetProduct(productId);
        }
    }


    [ObservableProperty]
    private Person _orderOwner;
    public int PersonId
    {
        set
        {
            int personId = value;
            if (personId > 0)
                OrderOwner = App.DataService.GetPerson(personId);
        }
    }


    private int _orderId;

    public int OrderId
    {
        get { return _orderId; }
        set { _orderId = value; }
    }


    [RelayCommand]
    private async void Done()
    {
        //Go Back To GoodsPage~~~
        var route = $"{Shell.Current.CurrentState.Location}/../..?" +
                    $"isOrder=true&personId={OrderOwner.Id}&orderId={OrderId}";
        await Shell.Current.GoToAsync(route);
    }
}














