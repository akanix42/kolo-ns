using System;
using NPoco;

namespace Kolo.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IDatabase Db { get; }
    }
}