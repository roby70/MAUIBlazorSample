using Blazor.Shared.Services;

using Microsoft.Extensions.Logging;

using MAUI.App.Services;
using Microsoft.Extensions.Configuration;
using APIServices;

namespace MAUI.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);


        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        var baseAddress = builder.Configuration["ApiSettings:BaseAddress"]
            ?? throw new NullReferenceException("Set ApiSettings:BaseAddress in appsettings.json");
        builder.Services.AddScoped(sp => new HttpClient { 
            BaseAddress = new Uri(baseAddress) 
        });
        builder.Services.AddScoped<IWeatherService, WeatherSerivceHttp>();

        // Add device-specific services used by the Blazor.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
