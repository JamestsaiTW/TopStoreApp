using CommunityToolkit.Mvvm.ComponentModel;

namespace TopStoreApp.ViewModels;

[QueryProperty(nameof(OrderDetailId), "orderDetailId")]
public partial class OrderDetailShowPageViewModel : BasePageViewModel
{
    [ObservableProperty]
    private Models.OrderDetailShow _orderDetailShow;

    public int OrderDetailId
    {
        set
        {
            //OrderDetailShow = App.DataService.GetOrderDetailShow(value);
        }
    }
}
