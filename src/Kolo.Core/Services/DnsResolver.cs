using Kolo.Core.DataAccess;
using Kolo.Core.DataAccess.Repositories;
using Kolo.Core.Models;

namespace Kolo.Core.Services
{
    public class DnsResolver : IDnsResolver
    {
        private readonly IDnsEntriesRepository dnsEntriesRepository;
        private readonly IUnitOfWorkProvider unitOfWorkProvider;

        public DnsResolver(IDnsEntriesRepository dnsEntriesRepository, IUnitOfWorkProvider unitOfWorkProvider)
        {
            this.dnsEntriesRepository = dnsEntriesRepository;
            this.unitOfWorkProvider = unitOfWorkProvider;
        }

        public DnsResolutionResult Resolve(DnsRequest dnsRequest)
        {
            var result = new DnsResolutionResult();
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
                result.DnsEntry = dnsEntriesRepository.FindDnsEntry(uow, dnsRequest);

            return result;
        }
    }
}