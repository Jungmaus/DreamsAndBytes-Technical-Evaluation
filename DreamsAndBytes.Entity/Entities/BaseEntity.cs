using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Entity.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
