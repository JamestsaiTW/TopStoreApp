namespace TopStoreApp;

public partial class App : Application
{
    internal static Services.IDataService DataService;
    public App()
    {
        InitializeComponent();

        var isDbService = Xamarin.Essentials.Preferences.Get("UserSwitchToDataService", false);
        DataService = isDbService ? Services.DbService.Instance : Utilities.MockData.Instance;

        MainPage = new AppShell();
    }

    protected override void OnStart()
    {
        PageDisappearing += (sender, e) => {
            System.Diagnostics.Debug.WriteLine(Shell.Current.CurrentState.Location);
        };
    }
}
