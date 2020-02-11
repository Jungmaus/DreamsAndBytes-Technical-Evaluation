using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Entity.Entities.User
{
    public class UserDetailEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
