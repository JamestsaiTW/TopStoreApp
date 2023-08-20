namespace TopStoreApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("People/PersonDetail", typeof(Pages.PersonDetailPage));
        Routing.RegisterRoute("Goods/ProductDetail", typeof(Pages.ProductDetailPage));
        Routing.RegisterRoute("Orders/OrderOwners", typeof(Pages.OrderOwnersPage));
        Routing.RegisterRoute("Orders/OrderOwners/OrderDetails", typeof(Pages.OrderDetailsPage));
        Routing.RegisterRoute("Orders/OrderOwners/OrderDetails/OrderDetailShow", 
                                typeof(Pages.OrderDetailShowPage));
    }
}