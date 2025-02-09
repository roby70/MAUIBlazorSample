using Blazor.Shared.Models;
using Blazor.Shared.Services;

using System.Net.Http.Json;

namespace APIServices;
public class WeatherSerivceHttp(HttpClient httpClient) : IWeatherService
{
    public const string BaseUrl = "/api/weather";

    public HttpClient HttpClient { get; } = httpClient;

    public async Task<WeatherForecast[]> GetAsync()
    {
        var forecasts = await HttpClient.GetFromJsonAsync<WeatherForecast[]>(BaseUrl);
        return forecasts ?? [];
    }
}
