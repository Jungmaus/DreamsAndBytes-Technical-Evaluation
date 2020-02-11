using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamsAndBytes.Entity.Entities.Product
{
    public class ProductTypeEntity : BaseEntity
    {
        public string Name { get; set; }

        // .... category etc.

        public virtual List<ProductEntity> Products { get; set; }
    }
}
