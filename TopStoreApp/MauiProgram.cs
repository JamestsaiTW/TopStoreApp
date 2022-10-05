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
            .RegisterAppViewsAndViewModels()
            .RegisterAppDataService();

        return builder.Build();
	}

    private static MauiAppBuilder RegisterAppViewsAndViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<Pages.PeoplePage>();
        builder.Services.AddSingleton<ViewModels.PeoplePageViewModel>();

        builder.Services.AddSingleton<Pages.GoodsPage>();
        builder.Services.AddSingleton<ViewModels.GoodsPageViewModel>();

        builder.Services.AddTransient<Pages.PersonDetailPage>();
        builder.Services.AddTransient<ViewModels.PersonDetailPageViewModel>();

        return builder;
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
