using Kolo.Core.Models;

namespace Kolo.Core.Services
{
    public interface IDnsResolver
    {
        DnsResolutionResult Resolve(DnsRequest dnsRequest);
    }
}