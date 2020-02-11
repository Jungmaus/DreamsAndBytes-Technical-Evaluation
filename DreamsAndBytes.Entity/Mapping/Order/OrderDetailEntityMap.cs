using DreamsAndBytes.Entity.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Entity.Mapping.Order
{
    public class OrderDetailEntityMap : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AddDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.ProductID).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.OrderID).IsRequired();

            builder.HasIndex(x => x.OrderID);
        }
    }
}
