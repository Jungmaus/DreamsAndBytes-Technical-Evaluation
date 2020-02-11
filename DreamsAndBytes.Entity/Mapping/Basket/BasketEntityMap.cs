using DreamsAndBytes.Entity.Entities.Basket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Entity.Mapping.Basket
{
    public class BasketEntityMap : IEntityTypeConfiguration<BasketEntity>
    {
        public void Configure(EntityTypeBuilder<BasketEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AddDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.ProductID).IsRequired();
            builder.Property(x => x.UserID).IsRequired();

            builder.HasIndex(x => x.UserID);
        }
    }
}
