namespace TopStoreApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("People/PersonDetail", typeof(Pages.PersonDetailPage));
        Routing.RegisterRoute("Goods/ProductDetail", typeof(Pages.ProductDetailPage));
        Routing.RegisterRoute("Orders/OrderOwners", typeof(Pages.OrderOwnersPage));
    }
}