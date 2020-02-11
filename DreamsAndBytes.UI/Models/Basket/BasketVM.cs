using DreamsAndBytes.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsAndBytes.UI.Models.Basket
{
    public class BasketVM
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public ProductEntity Product { get; set; }        
    }
}
