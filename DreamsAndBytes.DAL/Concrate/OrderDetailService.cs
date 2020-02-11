using DreamsAndBytes.Core;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.Entity.Context;
using DreamsAndBytes.Entity.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DreamsAndBytes.DAL.Concrate
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<OrderDetailEntity> _repo;

        public MssqlContext Context => this._uow.Context;

        public OrderDetailService(IUnitOfWork unit, IRepository<OrderDetailEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public void Add(OrderDetailEntity entity) => _repo.Add(entity);

        public void Delete(OrderDetailEntity entity) => _repo.Delete(entity);

        public IEnumerable<OrderDetailEntity> Get() => _repo.Get();

        public IEnumerable<OrderDetailEntity> Get(Expression<Func<OrderDetailEntity, bool>> predicate) => _repo.Get(predicate);
        public void HardDelete(OrderDetailEntity entity) => _repo.HardDelete(entity);

        public void Update(OrderDetailEntity entity) => _repo.Update(entity);

        public void SaveChanges() => _uow.SaveChanges();

        public void Dispose()
        {
            this._uow.Dispose();
        }
    }
}
