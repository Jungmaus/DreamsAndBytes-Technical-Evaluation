using DreamsAndBytes.Entity.Entities.Basket;
using DreamsAndBytes.Entity.Entities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamsAndBytes.Entity.Entities.User
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public int UserDetailID { get; set; }

        [ForeignKey("UserDetailID")]
        public virtual UserDetailEntity UserDetail { get; set; }
        public virtual List<BasketEntity> Baskets { get; set; }
        public virtual List<OrderEntity> Orders { get; set; }
    }
}
