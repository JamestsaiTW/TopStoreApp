using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TopStoreApp.Models;

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
            OrderDetailShow = App.DataService.GetOrderDetailShow(value);
        }
    }

    [ObservableProperty]
    private bool _isEdit;

    [RelayCommand]
    private async void Save()
    {
        if (IsEdit)
        {
            var orderDetail = App.DataService.GetOrderDetail(OrderDetailShow.OrderDetailId);

            if (orderDetail != null)
            {
                orderDetail.Quantity = OrderDetailShow.Quantity;
                orderDetail.Price = OrderDetailShow.Price;
                orderDetail.Note = OrderDetailShow.Note;

                var isValid = Utilities.ValidationHelper.IsValid(orderDetail, Shell.Current.CurrentPage);
                if (!isValid)
                    return;

                App.DataService.SaveOrderDetail(orderDetail);
            }

            var isBack = await Shell.Current.DisplayAlert("通知", "儲存成功!",
                                                                "返回訂單明細列表", "再檢視此筆資料");
            if (isBack)
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        IsEdit = !IsEdit;
    }
}
