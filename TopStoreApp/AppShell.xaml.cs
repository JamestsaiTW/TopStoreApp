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
        Routing.RegisterRoute("Orders/OrderOwners/OrderDetails/OrderDetailShow", typeof(Pages.OrderDetailShowPage));
        Routing.RegisterRoute("Orders/People", typeof(Pages.PeoplePage));
        Routing.RegisterRoute("Orders/People/Goods", typeof(Pages.GoodsPage));
        Routing.RegisterRoute("Orders/People/Goods/ProductDetail", typeof(Pages.ProductDetailPage));
        Routing.RegisterRoute("People/Goods", typeof(Pages.GoodsPage));
        Routing.RegisterRoute("People/Goods/ProductDetail", typeof(Pages.ProductDetailPage));
        Routing.RegisterRoute("People/Goods/ProductDetail/AddOrder", typeof(Pages.AddOrderPage));
        Routing.RegisterRoute("Orders/People/Goods/ProductDetail/AddOrder", typeof(Pages.AddOrderPage));
    }
}