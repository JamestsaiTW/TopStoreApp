using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopStoreApp
{
    public partial class App : Application
    {
        internal static Services.IDataService DataService;
        public App()
        {
            InitializeComponent();

            DataService = Utilities.MockData.Instance;

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
