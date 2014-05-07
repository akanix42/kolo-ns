using Kolo.Core.Models;

namespace Kolo.Core.DataAccess.Repositories
{
    public interface IDnsEntriesRepository
    {
        int AddDnsEntry(IUnitOfWork uow, DnsEntry dnsEntry);
        DnsEntry FindDnsEntry(IUnitOfWork uow, DnsRequest dnsRequest);
    }
}