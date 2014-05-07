using System.Data;
using NPoco;

namespace Kolo.Service.Tests.Integration
{
    public class NPocoUnitOfWork : IUnitOfWork
    {
        private readonly Transaction _transaction;
        private readonly Database _db;

        public NPocoUnitOfWork()
        {
            _db = new Database("KoloDb");
            _transaction = new Transaction(_db, IsolationLevel.ReadCommitted);
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public Database Db
        {
            get { return _db; }
        }

        public void Commit()
        {
            _transaction.Complete();
        }
    }
}