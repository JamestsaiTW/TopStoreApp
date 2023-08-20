using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TopStoreApp.Models;

namespace TopStoreApp.ViewModels;

[QueryProperty(nameof(OrderId), "orderId")]
[QueryProperty(nameof(OrderOwnerQueryString), "orderOwner")]
[QueryProperty(nameof(OrderDateQueryString), "orderDate")]
public partial class OrderDetailsPageViewModel : BasePageViewModel
{
    [ObservableProperty]
    private ObservableCollection<Models.OrderDetailDisplay> _orderDetailDisplays;

    [ObservableProperty]
    private string _orderOwner;

    [ObservableProperty]
    private string _orderDate;

    public int OrderId
    {
        set
        {
            OrderDetailDisplays = App.DataService.GetOrderDetailDisplays(value);
        }
    }

    public string OrderOwnerQueryString
    {
        set
        {
            OrderOwner = value;
        }
    }

    public string OrderDateQueryString
    {
        set
        {
            OrderDate = value;
        }
    }

    [RelayCommand]
    private async void Select(OrderDetailDisplay orderDetailDisplay)
    {
        //await Shell.Current.DisplayAlert("Order Detail Selected",
        //                                $"Order Detail: {orderDetailDisplay.ProductName}\r\n" +
        //                                $"OrderDetail Id: {orderDetailDisplay.OrderDetailId}", "OK");
        await Shell.Current.GoToAsync($"//Orders/OrderOwners/OrderDetails/OrderDetailShow?" +
                                      $"orderDetailId={orderDetailDisplay.OrderDetailId}");
    }
}
