using Xamarin.Forms;

namespace TopStoreApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("PersonDetail", typeof(Pages.PersonDetailPage));
        }
    }
}
