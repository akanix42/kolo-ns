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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/dnsentries/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/dnsentries
        public void Post(DnsEntry dnsEntry)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                dnsEntriesRepository.AddDnsEntry(uow, dnsEntry);
                uow.Commit();
            }
        }

        // PUT api/dnsentries/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/dnsentries/5
        public void Delete(int id)
        {
        }
    }
}
