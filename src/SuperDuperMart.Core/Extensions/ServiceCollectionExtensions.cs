using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperDuperMart.Core.Data;
using SuperDuperMart.Core.Data.Repositories;

namespace SuperDuperMart.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddDbContext<SuperDuperMartDbContext>(options =>
            {
                if (isDevelopment)
                {
                    options.UseSqlServer(configuration.GetConnectionString("Local"));
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("Azure"));
                }

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services
                .AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<SuperDuperMartDbContext>();

            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
