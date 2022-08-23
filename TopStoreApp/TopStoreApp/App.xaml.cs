using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopStoreApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Pages.PeoplePage();
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
