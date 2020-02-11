using DreamsAndBytes.Core;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.Entity.Context;
using DreamsAndBytes.Entity.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DreamsAndBytes.DAL.Concrate
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<BasketEntity> _repo;

        public MssqlContext Context => this._uow.Context;

        public BasketService(IUnitOfWork unit, IRepository<BasketEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public void Add(BasketEntity entity) => _repo.Add(entity);

        public void Delete(BasketEntity entity) => _repo.Delete(entity);

        public IEnumerable<BasketEntity> Get() => _repo.Get();

        public IEnumerable<BasketEntity> Get(Expression<Func<BasketEntity, bool>> predicate) => _repo.Get(predicate);
        public void HardDelete(BasketEntity entity) => _repo.HardDelete(entity);

        public void Update(BasketEntity entity) => _repo.Update(entity);

        public void SaveChanges() => _uow.SaveChanges();

        public void Dispose()
        {
            this._uow.Dispose();
        }
    }
}
