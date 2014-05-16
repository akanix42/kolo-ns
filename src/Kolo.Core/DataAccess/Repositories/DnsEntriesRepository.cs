using System;
using Kolo.Core.Models;
using NPoco;

namespace Kolo.Core.DataAccess.Repositories
{
    public class DnsEntriesRepository : IDnsEntriesRepository
    {

        public DnsEntriesRepository(IUnitOfWorkProvider unitOfWorkProvider)
        {
        }
        public int AddDnsEntry(IUnitOfWork uow, DnsEntry dnsEntry)
        {
            return Convert.ToInt32(uow.Db.Insert(dnsEntry));
        }

        public DnsEntry FindDnsEntry(IUnitOfWork uow, DnsRequest dnsRequest)
        {
            return uow.Db.FirstOrDefault<DnsEntry>(new Sql()
                .Append("SELECT * FROM dns_entries dnsEntry")
                .Append("WHERE dnsEntry.Name = @name", new { name = dnsRequest.Name })
                .Append("AND dnsEntry.Type = @type", new { type = dnsRequest.Type })
                );
        }

        public void DeleteAllEntries(IUnitOfWork uow)
        {
            uow.Db.Execute(new Sql()
                .Append("DELETE FROM dns_entries"));
        }
    }
}