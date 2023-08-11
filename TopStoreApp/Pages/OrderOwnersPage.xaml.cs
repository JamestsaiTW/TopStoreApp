using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace TopStoreApp.Pages;

public partial class OrderOwnersPage : ContentPage
{
    private OrderOwnersPage()
    {
        InitializeComponent();
    }

    public OrderOwnersPage(ViewModels.OrderOwnersPageViewModel orderOwnersPageViewModel) : this()
    {
        BindingContext = orderOwnersPageViewModel;
    }
}