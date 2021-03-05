using Xamarin.Forms;

namespace TopStoreApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("PersonDetailPage", typeof(Pages.PersonDetailPage));
        }
    }
}
