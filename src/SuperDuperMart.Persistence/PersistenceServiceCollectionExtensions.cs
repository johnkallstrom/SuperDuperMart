using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperDuperMart.Persistence.Data;
using SuperDuperMart.Persistence.Repositories;

namespace SuperDuperMart.Persistence
{
    public static class PersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SuperDuperMartDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<Customer>, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
