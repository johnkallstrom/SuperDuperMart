using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SuperDuperMart.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(c => c.Id);

            builder
                .HasOne(c => c.Address)
                .WithOne(a => a.Customer)
                .HasForeignKey<Address>(a => a.CustomerId);

            builder.Property(c => c.Created).ValueGeneratedOnAdd();
        }
    }
}
