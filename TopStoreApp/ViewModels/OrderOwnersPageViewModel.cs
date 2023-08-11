using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

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
}

