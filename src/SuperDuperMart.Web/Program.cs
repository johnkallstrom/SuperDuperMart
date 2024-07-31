using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SuperDuperMart.Web.AuthenticationProviders;
using SuperDuperMart.Web.Http;

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
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

var host = builder.Build();
await host.RunAsync();
