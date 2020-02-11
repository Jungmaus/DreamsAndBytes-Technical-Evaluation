using DreamsAndBytes.Entity.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Entity.Mapping.Product
{
    public class ProductEntityMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AddDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ProductTypeId).IsRequired();
            builder.Property(x => x.StockCount).IsRequired();

        }
    }
}
