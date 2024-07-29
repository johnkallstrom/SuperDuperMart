using SuperDuperMart.Api.Extensions;
using SuperDuperMart.Core.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithBearerAuthorization();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddCoreServices(builder.Configuration, builder.Environment.IsDevelopment());

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //await app.SeedDatabaseAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();
app.UseJwtMiddleware();

app.UseExceptionHandler();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
