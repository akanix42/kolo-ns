using System;
using System.Collections.Generic;
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

        public void UpdateDnsEntry(IUnitOfWork uow, DnsEntry dnsEntry)
        {
            uow.Db.Update(dnsEntry);
        }

        public DnsEntry GetDnsEntry(IUnitOfWork uow, int dnsEntryId)
        {
            return uow.Db.FirstOrDefault<DnsEntry>(new Sql()
               .Append("SELECT * FROM dns_entries dnsEntry")
               .Append("WHERE dnsEntry.Id = @dnsEntryId", new { dnsEntryId })
               );
        }

        public List<DnsEntry> GetAllDnsEntries(IUnitOfWork uow)
        {
            return uow.Db.Fetch<DnsEntry>(new Sql()
                .Append("SELECT * FROM dns_entries dnsEntry")
                );
        }

        public void DeleteDnsEntry(IUnitOfWork uow, int dnsEntryId)
        {
            uow.Db.Execute(new Sql()
                .Append("DELETE dnsEntry FROM dns_entries dnsEntry")
                .Append("WHERE dnsEntry.Id = @dnsEntryId", new {dnsEntryId})
                );
        }
    }
}