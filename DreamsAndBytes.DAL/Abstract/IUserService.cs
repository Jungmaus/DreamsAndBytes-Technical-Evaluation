using DreamsAndBytes.Core;
using DreamsAndBytes.Entity.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.DAL.Abstract
{
    public interface IUserService : IRepository<UserEntity>, IUnitOfWork
    {
    }
}
