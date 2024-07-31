using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SuperDuperMart.Core.Data.EntityConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.TotalCost).HasPrecision(5, 2);
            builder.Property(c => c.Created).ValueGeneratedOnAdd();

            // One-to-Many relationship with User
            builder
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId);
        }
    }
}
