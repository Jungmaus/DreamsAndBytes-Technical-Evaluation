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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<UserEntity> _repo;

        public MssqlContext Context => this._uow.Context;

        public UserService(IUnitOfWork unit, IRepository<UserEntity> repo)
        {
            _uow = unit;
            _repo = repo;
        }

        public void Add(UserEntity entity) => _repo.Add(entity);

        public void Delete(UserEntity entity) => _repo.Delete(entity);

        public IEnumerable<UserEntity> Get() => _repo.Get();

        public IEnumerable<UserEntity> Get(Expression<Func<UserEntity, bool>> predicate) => _repo.Get(predicate);
        public void HardDelete(UserEntity entity) => _repo.HardDelete(entity);

        public void Update(UserEntity entity) => _repo.Update(entity);

        public void SaveChanges() => _uow.SaveChanges();

        public void Dispose()
        {
            this._uow.Dispose();
        }
    }
}
