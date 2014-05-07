namespace Kolo.Service.Tests.Integration
{
    public class NPocoUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork GetUnitOfWork()
        {
            return new NPocoUnitOfWork();
        }
    }
}