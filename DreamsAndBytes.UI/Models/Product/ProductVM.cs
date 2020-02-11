using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsAndBytes.UI.Models.Product
{
    public class ProductVM
    {
        public int ID { get; set; }
        [MaxLength(50),Required,DataType(DataType.Text)]
        public string Name { get; set; }
        [Range(0,int.MaxValue), Required]
        public int StockCount { get; set; }
        [Range(0, double.MaxValue), Required]
        public decimal Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public IFormFile Image { get; set; }
    }
}
