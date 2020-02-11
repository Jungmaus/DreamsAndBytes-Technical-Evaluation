using DreamsAndBytes.Core;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.Entity.Context;
using DreamsAndBytes.Entity.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DreamsAndBytes.DAL.Concrate
{
    public class UserDetailService : IUserDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<UserDetailEntity> _repo;

        public MssqlContext Context => this._uow.Context;

        public UserDetailService(IUnitOfWork unit, IRepository<UserDetailEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public void Add(UserDetailEntity entity) => _repo.Add(entity);

        public void Delete(UserDetailEntity entity) => _repo.Delete(entity);

        public IEnumerable<UserDetailEntity> Get() => _repo.Get();

        public IEnumerable<UserDetailEntity> Get(Expression<Func<UserDetailEntity, bool>> predicate) => _repo.Get(predicate);
        public void HardDelete(UserDetailEntity entity) => _repo.HardDelete(entity);

        public void Update(UserDetailEntity entity) => _repo.Update(entity);

        public void SaveChanges() => _uow.SaveChanges();

        public void Dispose()
        {
            this._uow.Dispose();
        }
    }
}
