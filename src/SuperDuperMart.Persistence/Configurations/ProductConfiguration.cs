﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SuperDuperMart.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Price).HasPrecision(5, 2);
            builder.Property(p => p.Created).ValueGeneratedOnAdd();
            builder.Property(p => p.LastModified).ValueGeneratedOnUpdate();
        }
    }
}
