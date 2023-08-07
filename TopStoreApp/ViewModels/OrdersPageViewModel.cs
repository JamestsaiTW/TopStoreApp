using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TopStoreApp.Models;

namespace TopStoreApp.ViewModels;
    
public partial class OrdersPageViewModel : BasePageViewModel
{
    [ObservableProperty]
    private ObservableCollection<Models.SummaryOrder> _summaryOrders;

    [RelayCommand]
    private async void Select(SummaryOrder summaryOrder)
    {
        //await Shell.Current.DisplayAlert("Order Selected", $"{summaryOrder.Count}", "OK");
        await Shell.Current.GoToAsync($"//Orders/OrderOwners?orderDate={summaryOrder.Summary.Date}");
    }
}


