using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorDemo.MAUI.Shared.Services;
using MyBlazorDemo.MAUI.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the MyBlazorDemo.MAUI.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
