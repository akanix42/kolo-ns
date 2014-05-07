using System;
using NPoco;

namespace Kolo.Service.Tests.Integration
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Database Db { get; }
    }
}