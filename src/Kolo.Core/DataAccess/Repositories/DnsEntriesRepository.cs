using System;

namespace Kolo.Service.Tests.Integration
{
    public class DnsEntriesRepository : IDnsEntriesRepository
    {
        public int AddDnsEntry(IUnitOfWork uow, DnsEntry dnsEntry)
        {
            return Convert.ToInt32(uow.Db.Insert(dnsEntry));
        }
    }
}