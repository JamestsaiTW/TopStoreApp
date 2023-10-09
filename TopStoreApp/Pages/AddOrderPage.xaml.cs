namespace TopStoreApp.Pages;

public partial class AddOrderPage : ContentPage
{
	private AddOrderPage()
	{
		InitializeComponent();
	}

	public AddOrderPage(ViewModels.AddOrderPageViewModel viewModel) : this()
	{
        BindingContext = viewModel;
    }
}