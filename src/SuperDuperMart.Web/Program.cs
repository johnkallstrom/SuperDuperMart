using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using SuperDuperMart.Web.AuthenticationProviders;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7220")
});

builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();
