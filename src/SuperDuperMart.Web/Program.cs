using SuperDuperMart.Web.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:7220") 
});

builder.Services.AddScoped<IHttpService, HttpService>();

var host = builder.Build();
await host.RunAsync();
