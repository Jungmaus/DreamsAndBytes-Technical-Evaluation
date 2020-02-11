using DreamsAndBytes.Core;
using DreamsAndBytes.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.DAL.Abstract
{
    public interface IProductService : IRepository<ProductEntity>, IUnitOfWork
    {
    }
}
