using Blazor.Shared.Models;

namespace Blazor.Shared.Services;
public interface IWeatherService
{
    Task<WeatherForecast[]> GetAsync();
}
