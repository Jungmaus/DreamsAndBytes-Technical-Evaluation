using DreamsAndBytes.Entity.Entities.Product;
using DreamsAndBytes.Entity.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamsAndBytes.Entity.Entities.Order
{
    public class OrderDetailEntity : BaseEntity
    {
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrderID { get; set; }

        [ForeignKey("ProductID")]
        public virtual ProductEntity Product { get; set; }
        [ForeignKey("OrderID")]
        public virtual OrderEntity Order { get; set; }
    }
}
