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
                .HasOne(c => c.Location)
                .WithOne(a => a.User)
                .HasForeignKey<Location>(a => a.UserId);

            builder.Property(c => c.Created).ValueGeneratedOnAdd();
            builder.Property(c => c.LastModified).ValueGeneratedOnUpdate();
        }
    }
}
