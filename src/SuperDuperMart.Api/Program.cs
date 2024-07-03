using SuperDuperMart.Api.Extensions;

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
builder.Services.AddCoreServices();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

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
