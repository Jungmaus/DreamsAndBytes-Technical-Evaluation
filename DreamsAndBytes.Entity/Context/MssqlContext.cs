using DreamsAndBytes.Entity.Entities.Basket;
using DreamsAndBytes.Entity.Entities.Order;
using DreamsAndBytes.Entity.Entities.Product;
using DreamsAndBytes.Entity.Entities.User;
using DreamsAndBytes.Entity.Mapping.Basket;
using DreamsAndBytes.Entity.Mapping.Order;
using DreamsAndBytes.Entity.Mapping.Product;
using DreamsAndBytes.Entity.Mapping.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Entity.Context
{
    public class MssqlContext : DbContext
    {
        public MssqlContext(DbContextOptions<MssqlContext> dbContextOptions) : base (dbContextOptions) { }

        #region Basket

        public DbSet<BasketEntity> Baskets { get; set; }

        #endregion

        #region Order

        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }

        #endregion

        #region Product

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductTypeEntity> ProductTypes { get; set; }

        #endregion

        #region User

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserDetailEntity> UserDetails { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Basket Configuration
            modelBuilder.ApplyConfiguration(new BasketEntityMap());
            #endregion
            #region Order Configuration
            modelBuilder.ApplyConfiguration(new OrderDetailEntityMap());
            modelBuilder.ApplyConfiguration(new OrderEntityMap());
            #endregion
            #region Product Configuration
            modelBuilder.ApplyConfiguration(new ProductEntityMap());
            modelBuilder.ApplyConfiguration(new ProductTypeEntityMap());
            #endregion
            #region User Configuration
            modelBuilder.ApplyConfiguration(new UserEntityMap());
            modelBuilder.ApplyConfiguration(new UserDetailEntityMap());
            #endregion
        }
    }
}
