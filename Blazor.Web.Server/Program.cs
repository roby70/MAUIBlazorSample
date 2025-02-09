using Blazor.Web.Server.Components;
using Blazor.Web.Server.Services;
using Blazor.Shared.Services;
using Blazor.Web.Server.Endpoints.Weather;
using APIServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// Add device-specific services used by the Blazor.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddSingleton<IWeatherService, WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(Blazor.Shared._Imports).Assembly,
        typeof(Blazor.Web.Client._Imports).Assembly);

var weatherGroup = app.MapGroup(WeatherSerivceHttp.BaseUrl);
weatherGroup.MapWeatherEndpoints();

app.Run();
