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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<OrderEntity> _repo;

        public MssqlContext Context => this._uow.Context;

        public OrderService(IUnitOfWork unit, IRepository<OrderEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public void Add(OrderEntity entity) => _repo.Add(entity);

        public void Delete(OrderEntity entity) => _repo.Delete(entity);

        public IEnumerable<OrderEntity> Get() => _repo.Get();

        public IEnumerable<OrderEntity> Get(Expression<Func<OrderEntity, bool>> predicate) => _repo.Get(predicate);
        public void HardDelete(OrderEntity entity) => _repo.HardDelete(entity);

        public void Update(OrderEntity entity) => _repo.Update(entity);

        public void SaveChanges() => _uow.SaveChanges();

        public void Dispose()
        {
            this._uow.Dispose();
        }
    }
}
