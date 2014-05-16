using System.Collections.Generic;
using Kolo.Core.Models;

namespace Kolo.Core.DataAccess.Repositories
{
    public interface IDnsEntriesRepository
    {
        int AddDnsEntry(IUnitOfWork uow, DnsEntry dnsEntry);
        DnsEntry FindDnsEntry(IUnitOfWork uow, DnsRequest dnsRequest);
        void DeleteAllEntries(IUnitOfWork uow);
        void UpdateDnsEntry(IUnitOfWork uow, DnsEntry dnsEntry);
        DnsEntry GetDnsEntry(IUnitOfWork uow, int dnsEntryId);
        List<DnsEntry> GetAllDnsEntries(IUnitOfWork uow);
        void DeleteDnsEntry(IUnitOfWork uow, int dnsEntryId);
    }
}