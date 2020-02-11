using DreamsAndBytes.Core;
using DreamsAndBytes.Entity.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.DAL.Abstract
{
    public interface IBasketService : IRepository<BasketEntity>, IUnitOfWork
    {
    }
}
