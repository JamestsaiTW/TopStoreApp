using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace TopStoreApp.ViewModels;
    
public partial class OrdersPageViewModel : BasePageViewModel
{
    [ObservableProperty]
    private ObservableCollection<Models.SummaryOrder> _summaryOrders;
}

