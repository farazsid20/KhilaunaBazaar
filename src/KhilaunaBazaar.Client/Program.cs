using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KhilaunaBazaar.Client;
using KhilaunaBazaar.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBase = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5000";
try
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBase) });
}
catch
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5000") });
}
builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<CartService>();

await builder.Build().RunAsync();
