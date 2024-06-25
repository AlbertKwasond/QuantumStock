using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QuantumStock.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<SalesService>();

//builder.RootComponents.Add<App>("#app");

// Register HttpClient
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
