using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace TopStoreApp.Pages;

public partial class GoodsPage : ContentPage
{
    private GoodsPage()
    {
        InitializeComponent();
    }

    public GoodsPage(ViewModels.GoodsPageViewModel goodsPageViewModel) : this()
    {
        BindingContext = goodsPageViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ViewModels.GoodsPageViewModel;
        vm.Goods = App.DataService.GetGoods();
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var vm = BindingContext as ViewModels.GoodsPageViewModel;
        if (e.NewTextValue?.Length == 0 && e.OldTextValue?.Length > 0)
        {
            vm.SearchCommand.Execute(string.Empty);
        }
    }
}
