using DreamsAndBytes.Core;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.Entity.Context;
using DreamsAndBytes.Entity.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DreamsAndBytes.DAL.Concrate
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<ProductEntity> _repo;

        public MssqlContext Context => this._uow.Context;

        public ProductService(IUnitOfWork unit, IRepository<ProductEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public void Add(ProductEntity entity) => _repo.Add(entity);

        public void Delete(ProductEntity entity) => _repo.Delete(entity);

        public IEnumerable<ProductEntity> Get() => _repo.Get();

        public IEnumerable<ProductEntity> Get(Expression<Func<ProductEntity, bool>> predicate) => _repo.Get(predicate);
        public void HardDelete(ProductEntity entity) => _repo.HardDelete(entity);

        public void Update(ProductEntity entity) => _repo.Update(entity);

        public void SaveChanges() => _uow.SaveChanges();

        public void Dispose()
        {
            this._uow.Dispose();
        }
    }
}
