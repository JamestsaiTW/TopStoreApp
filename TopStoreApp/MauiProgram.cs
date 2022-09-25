namespace TopStoreApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FontAwesome5.otf", "FA5");
			})
			.RegisterAppDataService();

        return builder.Build();
	}

    private static MauiAppBuilder RegisterAppDataService(this MauiAppBuilder builder)
    {
        var isDbService = Preferences.Get("UserSwitchToDataService", false);

        if (isDbService)
            builder.Services.AddSingleton<Services.IDataService, Services.DbService>();
        else
            builder.Services.AddSingleton<Services.IDataService, Utilities.MockData>();

        return builder;
    }
}
