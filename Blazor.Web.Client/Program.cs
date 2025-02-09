using APIServices;

using Blazor.Shared.Services;
using Blazor.Web.Client.Services;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the Blazor.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();


builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IWeatherService, WeatherSerivceHttp>();

await builder.Build().RunAsync();
