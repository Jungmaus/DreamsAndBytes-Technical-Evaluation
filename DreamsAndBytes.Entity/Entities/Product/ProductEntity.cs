using DreamsAndBytes.Entity.Entities.Basket;
using DreamsAndBytes.Entity.Entities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamsAndBytes.Entity.Entities.Product
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; } 
        public int ProductTypeId { get; set; }
        public int StockCount { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey("ProductTypeId")]
        public virtual ProductTypeEntity ProductType { get; set; }
        public virtual List<BasketEntity> Baskets { get; set; }
        public virtual List<OrderDetailEntity> OrderDetails { get; set; }
    }
}
