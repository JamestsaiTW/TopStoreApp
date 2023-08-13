using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TopStoreApp.Models;

namespace TopStoreApp.ViewModels;

[QueryProperty(nameof(OrderDateQueryString), "orderDate")]
public partial class OrderOwnersPageViewModel : BasePageViewModel
{
    [ObservableProperty]
    private ObservableCollection<Models.OrderOwner> _orderOwners;

    [ObservableProperty]
    private DateTime _orderDate;

    public string OrderDateQueryString
    {
        set
        {
            OrderDate = DateTime.Parse(value);
            
            OrderOwners = App.DataService.GetOrderOwners(OrderDate);
        }
    }

    [RelayCommand]
    private async void Select(OrderOwner order)
    {
        await Shell.Current.DisplayAlert("Order Selected",
                                        $"Order Owner: {order.Owner}\r\n" +
                                        $"Order Id: {order.OrderId}", "OK");
    }
}

