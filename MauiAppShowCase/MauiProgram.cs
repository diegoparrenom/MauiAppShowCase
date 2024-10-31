using Microsoft.Extensions.Logging;
using MauiAppShowCase.Services;
using MauiAppShowCase.View;
namespace MauiAppShowCase
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = FileAccessHelper.GetLocalFilePath("peopledb1.db3");
            builder.Services.AddSingleton<ProductRepository>
                (s => ActivatorUtilities.CreateInstance<ProductRepository>(s,dbPath));   
#if DEBUG
    		builder.Logging.AddDebug();
#endif
		    builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddSingleton<IMap>(Map.Default);

		    builder.Services.AddSingleton<ProductsViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<ProductManageViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddTransient<ProductManagePage>();

            return builder.Build();
        }
    }
}
