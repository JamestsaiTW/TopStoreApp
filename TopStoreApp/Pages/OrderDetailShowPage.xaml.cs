namespace TopStoreApp.Pages;

public partial class OrderDetailShowPage : ContentPage
{
	private OrderDetailShowPage()
	{
		InitializeComponent();
	}

    public OrderDetailShowPage(ViewModels.OrderDetailShowPageViewModel orderDetailShowPageViewModel) : this()
    {
        BindingContext = orderDetailShowPageViewModel;
    }
}