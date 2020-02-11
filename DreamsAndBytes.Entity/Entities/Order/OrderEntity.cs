using DreamsAndBytes.Entity.Entities.User;
using DreamsAndBytes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamsAndBytes.Entity.Entities.Order
{
    public class OrderEntity : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }

        public OrderStatusEnum OrderStatus { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual UserEntity User { get; set; }

        public virtual List<OrderDetailEntity> OrderDetails { get; set; }
    }
}
