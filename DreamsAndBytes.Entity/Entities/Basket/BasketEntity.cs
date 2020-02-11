using DreamsAndBytes.Entity.Entities.Product;
using DreamsAndBytes.Entity.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamsAndBytes.Entity.Entities.Basket
{
    public class BasketEntity : BaseEntity
    {
        public BasketEntity()
        {

        }

        public BasketEntity(int userId, int productId, int count, DateTime addDate, bool isDeleted)
        {
            this.UserID = userId;
            this.ProductID = productId;
            this.Count = count;
            this.AddDate = AddDate;
            this.IsDeleted = isDeleted;
        }

        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }

        [ForeignKey("UserID")]
        public virtual UserEntity User { get; set; }

        [ForeignKey("ProductID")]
        public virtual ProductEntity Product { get; set; }
    }
}
