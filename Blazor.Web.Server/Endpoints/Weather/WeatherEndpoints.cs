using Blazor.Shared.Services;

namespace Blazor.Web.Server.Endpoints.Weather;

// File: WeatherEndpoints.cs
public static class WeatherEndpoints
{
    public static RouteGroupBuilder MapWeatherEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", (IWeatherService weatherService) =>
        {
            return weatherService.GetAsync();
        });

        return group;
    }
}
