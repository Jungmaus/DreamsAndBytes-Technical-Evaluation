using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsAndBytes.API.Models.Product
{
    public class ProductModel
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public int StockCount { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }
}
