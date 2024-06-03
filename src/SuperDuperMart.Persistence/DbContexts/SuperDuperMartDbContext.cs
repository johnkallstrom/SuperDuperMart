using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SuperDuperMart.Persistence.DbContexts
{
    public class SuperDuperMartDbContext : DbContext
    {
        public SuperDuperMartDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
