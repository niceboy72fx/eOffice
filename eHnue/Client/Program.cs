using eHnue.Client;
using eHnue.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddSingleton<ILocalStorage, LocalStorage>(); // NOTE: this line is newly added

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
await builder.Build().RunAsync();
