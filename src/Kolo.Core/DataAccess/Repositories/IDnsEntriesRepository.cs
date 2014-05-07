namespace Kolo.Service.Tests.Integration
{
    public interface IDnsEntriesRepository
    {
        int AddDnsEntry(IUnitOfWork uow, DnsEntry dnsEntry);
    }
}