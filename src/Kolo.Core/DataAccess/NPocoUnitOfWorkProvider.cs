namespace Kolo.Core.DataAccess
{
    public class NPocoUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork GetUnitOfWork()
        {
            return new NPocoUnitOfWork();
        }
    }
}