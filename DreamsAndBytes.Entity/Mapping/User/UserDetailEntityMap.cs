using DreamsAndBytes.Entity.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Entity.Mapping.User
{
    public class UserDetailEntityMap : IEntityTypeConfiguration<UserDetailEntity>
    {
        public void Configure(EntityTypeBuilder<UserDetailEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AddDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(25);
            builder.Property(x => x.Surname).HasMaxLength(25);
            builder.Property(x => x.PhoneNumber).HasMaxLength(25);

            builder.HasIndex(x => x.ID);
        }
    }
}
