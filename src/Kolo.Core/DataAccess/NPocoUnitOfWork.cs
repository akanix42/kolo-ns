using System.Data;
using NPoco;

namespace Kolo.Core.DataAccess
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

        public IDatabase Db
        {
            get { return _db; }
        }

        public void Commit()
        {
            _transaction.Complete();
        }
    }
}