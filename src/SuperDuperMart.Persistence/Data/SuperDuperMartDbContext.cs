using Microsoft.EntityFrameworkCore;
using SuperDuperMart.Core.Entities;
using System.Reflection;

namespace SuperDuperMart.Persistence.Data
{
    public class SuperDuperMartDbContext : DbContext
    {
        public SuperDuperMartDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
