using DreamsAndBytes.Entity.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsAndBytes.Core
{
    public interface IUnitOfWork : IDisposable
    {
        MssqlContext Context { get; }
        void SaveChanges();
    }

}
