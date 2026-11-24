using Microsoft.Extensions.Logging;
using MauiWeather_Application.Services;
using MauiWeather_Application.ViewModels;


namespace MauiWeather_Application
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<IGeolocationService, GeolocationService>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<AppShell>();
            
            builder.Services.AddHttpClient<IWeatherService, WeatherService>();
            
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
