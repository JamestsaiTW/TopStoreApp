namespace TopStoreApp;

public partial class App : Application
{
    public static Services.IDataService DataService { get; private set; }
    private App()
    {
        InitializeComponent();

        //var isDbService = Preferences.Get("UserSwitchToDataService", false);
        //DataService = isDbService ? Services.DbService.Instance : Utilities.MockData.Instance;

        MainPage = new AppShell();
    }

    public App(Services.IDataService dataService) : this()
    {
        DataService = dataService;
    }

    protected override void OnStart()
    {
        PageDisappearing += (sender, e) =>
        {
            System.Diagnostics.Debug.WriteLine(Shell.Current.CurrentState.Location);
        };
    }
}
