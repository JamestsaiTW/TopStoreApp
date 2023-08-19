namespace TopStoreApp.Pages;

public partial class OrderDetailsPage : ContentPage
{
	private OrderDetailsPage()
	{
		InitializeComponent();
	}

    public OrderDetailsPage(ViewModels.OrderDetailsPageViewModel orderDetailsPageViewModel) : this()
    {
        BindingContext = orderDetailsPageViewModel;
    }
}