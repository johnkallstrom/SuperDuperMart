using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SuperDuperMart.Persistence.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Created).ValueGeneratedOnAdd();
            builder.Property(a => a.LastModified).ValueGeneratedOnUpdate();
        }
    }
}
