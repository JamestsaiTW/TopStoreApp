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
        builder.Services.AddTransient<Pages.PeoplePage>();
        builder.Services.AddTransient<ViewModels.PeoplePageViewModel>();

        builder.Services.AddTransient<Pages.GoodsPage>();
        builder.Services.AddTransient<ViewModels.GoodsPageViewModel>();

        builder.Services.AddSingleton<Pages.OrdersPage>();
        builder.Services.AddSingleton<ViewModels.OrdersPageViewModel>();

        builder.Services.AddTransient<Pages.PersonDetailPage>();
        builder.Services.AddTransient<ViewModels.PersonDetailPageViewModel>();

        builder.Services.AddTransient<Pages.ProductDetailPage>();
        builder.Services.AddTransient<ViewModels.ProductDetailPageViewModel>();

        builder.Services.AddTransient<Pages.OrderOwnersPage>();
        builder.Services.AddTransient<ViewModels.OrderOwnersPageViewModel>();

        builder.Services.AddTransient<Pages.OrderDetailsPage>();
        builder.Services.AddTransient<ViewModels.OrderDetailsPageViewModel>();

        builder.Services.AddTransient<Pages.OrderDetailShowPage>();
        builder.Services.AddTransient<ViewModels.OrderDetailShowPageViewModel>();

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
