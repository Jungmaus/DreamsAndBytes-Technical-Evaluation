using DreamsAndBytes.Core;
using DreamsAndBytes.Entity.Entities.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.DAL.Abstract
{
    public interface IOrderService : IRepository<OrderEntity>, IUnitOfWork
    {
    }
}
