using DreamsAndBytes.Entity.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Entity.Mapping.User
{
    public class UserEntityMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AddDate).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(25).IsRequired();

            builder.HasIndex(x => x.ID);
        }
    }
}
