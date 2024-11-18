using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Core.Data;

namespace SuperDuperMart.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public async static Task SeedDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SuperDuperMartDbContext>();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();

                await DatabaseInitializer.SeedAsync(
                    context, 
                    configuration, 
                    userManager,
                    roleManager);
            }
        }
    }
}
