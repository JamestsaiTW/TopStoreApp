namespace TopStoreApp.Pages;

public partial class ProductDetailPage : ContentPage
{
	private ProductDetailPage()
	{
		InitializeComponent();
	}

    public ProductDetailPage(ViewModels.ProductDetailPageViewModel productDetailPageViewModel) : this()
    {
        BindingContext = productDetailPageViewModel;
    }
}