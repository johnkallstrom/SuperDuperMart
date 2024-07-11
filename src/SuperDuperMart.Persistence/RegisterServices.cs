using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperDuperMart.Persistence.DbContexts;
using SuperDuperMart.Persistence.Repositories;

namespace SuperDuperMart.Persistence
{
    public static class RegisterServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDbContext<SuperDuperMartDbContext>(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.UseSqlServer(configuration.GetConnectionString("Local"));
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("Azure"));
                }

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
