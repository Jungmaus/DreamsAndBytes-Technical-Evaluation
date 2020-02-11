using DreamsAndBytes.Entity.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Entity.Mapping.Order
{
    public class OrderEntityMap : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AddDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.OrderStatus).IsRequired();
            builder.Property(x => x.PaymentType).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.UserID).IsRequired();

            builder.HasIndex(x => x.ID);
        }
    }
}
