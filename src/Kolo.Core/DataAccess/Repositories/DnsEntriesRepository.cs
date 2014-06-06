using System;
using System.Collections.Generic;
using AutoMapper;
using Kolo.Core.Models;
using NPoco;

namespace Kolo.Core.DataAccess.Repositories
{
    public class DnsEntriesRepository : IDnsEntriesRepository
    {
        public int AddDnsEntry(IUnitOfWork uow, DnsEntry dnsEntry)
        {
            dnsEntry.Name = dnsEntry.Name.Replace('*', '%');
            return Convert.ToInt32(uow.Db.Insert(dnsEntry));
        }

        public DnsEntry FindDnsEntry(IUnitOfWork uow, DnsRequest dnsRequest)
        {
            return Mapper.Map<Core.Models.DnsEntry>(uow.Db.FirstOrDefault<SQL.Models.DnsEntry>(
                new Sql()
                    .Append("SELECT * FROM dns_entries dnsEntry")
                    .Append("WHERE dnsEntry.Name = @name", new {name = dnsRequest.Name})
                    .Append("AND dnsEntry.Type = @type", new {type = dnsRequest.Type})
                ));
        }

        public DnsEntry FindDnsEntryWithWildcard(IUnitOfWork uow, DnsRequest dnsRequest)
        {
            return Mapper.Map<Core.Models.DnsEntry>(uow.Db.FirstOrDefault<SQL.Models.DnsEntry>(
                new Sql()
                    .Append("SELECT * FROM dns_entries dnsEntry")
                    .Append("WHERE dnsEntry.Name LIKE @name", new { name = dnsRequest.Name })
                    .Append("AND dnsEntry.Type = @type", new { type = dnsRequest.Type })
                ));
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
            return Mapper.Map<Core.Models.DnsEntry>(uow.Db.FirstOrDefault<SQL.Models.DnsEntry>(
                new Sql()
                    .Append("SELECT * FROM dns_entries dnsEntry")
                    .Append("WHERE dnsEntry.Id = @dnsEntryId", new {dnsEntryId})
                ));
        }

        public List<DnsEntry> GetAllDnsEntries(IUnitOfWork uow)
        {
            return Mapper.Map<List<Core.Models.DnsEntry>>(uow.Db.Fetch<SQL.Models.DnsEntry>(new Sql()
                .Append("SELECT * FROM dns_entries dnsEntry")
                ));
        }

        public void DeleteDnsEntry(IUnitOfWork uow, int dnsEntryId)
        {
            uow.Db.Execute(new Sql()
                .Append("DELETE dnsEntry FROM dns_entries dnsEntry")
                .Append("WHERE dnsEntry.Id = @dnsEntryId", new { dnsEntryId })
                );
        }
    }
}