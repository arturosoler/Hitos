using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;
using hitos;
using MudBlazor.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

//await builder.Build().RunAsync();
builder.Services.AddLocalization();
var host=builder.Build();

//Localización
var localStorage=host.Services.GetRequiredService<Blazored.LocalStorage.ILocalStorageService>();
CultureInfo culture;
var cultureString= await localStorage.GetItemAsync<string>("Cultura");
if (cultureString != null)
{
    culture = new CultureInfo(cultureString);
}
else
{
    culture=new CultureInfo("es-ES");
    await localStorage.SetItemAsync<string>("Cultura","es-ES") ;
}
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
await host.RunAsync();

