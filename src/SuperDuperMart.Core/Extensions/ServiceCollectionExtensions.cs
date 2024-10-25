using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperDuperMart.Core.Data;
using SuperDuperMart.Core.Data.Repositories;

namespace SuperDuperMart.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SuperDuperMartDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Local"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<SuperDuperMartDbContext>();

            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IPaginatedRepository<Product>, ProductRepository>();
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
