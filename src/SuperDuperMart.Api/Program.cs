using SuperDuperMart.Api.Authorization;
using SuperDuperMart.Api.Models;
using SuperDuperMart.Api.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddTransient<IJwtProvider, JwtProvider>();
builder.Services.AddAuthorization();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //await app.SeedDatabaseAsync();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseJwtMiddleware();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
