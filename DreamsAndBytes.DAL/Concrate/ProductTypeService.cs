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
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<ProductTypeEntity> _repo;

        public MssqlContext Context => this._uow.Context;

        public ProductTypeService(IUnitOfWork unit, IRepository<ProductTypeEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public void Add(ProductTypeEntity entity) => _repo.Add(entity);

        public void Delete(ProductTypeEntity entity) => _repo.Delete(entity);

        public IEnumerable<ProductTypeEntity> Get() => _repo.Get();

        public IEnumerable<ProductTypeEntity> Get(Expression<Func<ProductTypeEntity, bool>> predicate) => _repo.Get(predicate);
        public void HardDelete(ProductTypeEntity entity) => _repo.HardDelete(entity);

        public void Update(ProductTypeEntity entity) => _repo.Update(entity);

        public void SaveChanges() => _uow.SaveChanges();

        public void Dispose()
        {
            this._uow.Dispose();
        }
    }
}
