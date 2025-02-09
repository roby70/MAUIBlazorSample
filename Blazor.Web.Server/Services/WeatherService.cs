using Blazor.Shared.Models;
using Blazor.Shared.Services;

namespace Blazor.Web.Server.Services;

public class WeatherService : IWeatherService
{
    public Task<WeatherForecast[]> GetAsync()
    {
        // Qui puoi ritornare i dati meteo “fake” come nel template
        var summaries = new[]
        {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild",
                "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
        var forecasts = Enumerable.Range(1, 5).Select(index =>
        {
            return new WeatherForecast(
                DateTime.Now.AddDays(index),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            );
        }).ToArray();

        return Task.FromResult(forecasts);
    }
}
