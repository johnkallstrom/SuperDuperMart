using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SuperDuperMart.Core.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            // One-to-One relationship with Location
            builder
                .HasOne(c => c.Location)
                .WithOne(a => a.User)
                .HasForeignKey<Location>(a => a.UserId);
        }
    }
}
