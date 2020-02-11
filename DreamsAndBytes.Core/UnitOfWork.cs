using DreamsAndBytes.Entity.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        public MssqlContext Context { get; }

        public UnitOfWork(MssqlContext context)
        {
            Context = context;
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
