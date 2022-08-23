using Xamarin.Forms;

namespace TopStoreApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("People/PersonDetail", typeof(Pages.PersonDetailPage));
        }
    }
}
