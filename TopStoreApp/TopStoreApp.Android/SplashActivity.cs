using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TopStoreApp.Droid
{
    [Activity(Label = "TopStoreApp", Theme = "@style/LauncherTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            System.Threading.Tasks.Task startupWork = new System.Threading.Tasks.Task(() =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            });
            startupWork.Start();
        }
        public override void OnBackPressed() { }
    }
}