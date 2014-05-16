using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kolo.Core.DataAccess;
using Kolo.Core.DataAccess.Repositories;
using Kolo.Core.Models;

namespace Kolo.Web.Controllers
{
    public class DnsEntriesController : ApiController
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;
        private readonly IDnsEntriesRepository dnsEntriesRepository;

        public DnsEntriesController(IUnitOfWorkProvider unitOfWorkProvider, IDnsEntriesRepository dnsEntriesRepository)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.dnsEntriesRepository = dnsEntriesRepository;
        }

        // GET api/dnsentries
        public List<DnsEntry> Get()
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                return dnsEntriesRepository.GetAllDnsEntries(uow);
            }
        }

        // GET api/dnsentries/5
        public DnsEntry Get(int id)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                return dnsEntriesRepository.GetDnsEntry(uow,id);
            }
        }

        // POST api/dnsentries
        public void Post(DnsEntry dnsEntry)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                dnsEntry.FullName = dnsEntry.Name;
                dnsEntriesRepository.AddDnsEntry(uow, dnsEntry);
                uow.Commit();
            }
        }

        // PUT api/dnsentries/5
        public void Put(int id, DnsEntry dnsEntry)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                dnsEntry.FullName = dnsEntry.Name;
                dnsEntriesRepository.UpdateDnsEntry(uow, dnsEntry);
                uow.Commit();
            }
        }

        // DELETE api/dnsentries/5
        public void Delete(int id)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                dnsEntriesRepository.DeleteDnsEntry(uow, id);

                uow.Commit();
            }
        }
    }
}
