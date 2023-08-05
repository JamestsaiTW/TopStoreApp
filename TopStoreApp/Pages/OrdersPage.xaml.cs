using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace TopStoreApp.Pages;

public partial class OrdersPage : ContentPage
{
    private OrdersPage()
    {
        InitializeComponent();
    }

    public OrdersPage(ViewModels.OrdersPageViewModel ordersPageViewModel) : this()
    {
        BindingContext = ordersPageViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ViewModels.OrdersPageViewModel;
        vm.SummaryOrders = App.DataService.GetSummaryOrders();
    }
}