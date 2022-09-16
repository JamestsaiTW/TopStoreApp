namespace TopStoreApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("People/PersonDetail", typeof(Pages.PersonDetailPage));
        }
    }
}