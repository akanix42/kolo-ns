using FluentAssertions;
using Kolo.Core.DataAccess;
using Kolo.Core.DataAccess.Repositories;
using Kolo.Core.Models;
using Kolo.Core.Services;
using Moq;
using NUnit.Framework;

namespace Kolo.Core.Tests.Unit
{
    [TestFixture]
    class DnsResolver_Tests
    {
        [Test]
        public void Should_Not_Resolve_Dns_Query_Because_No_Entry_Matches()
        {
            var dnsEntriesRepository = Mock.Of<IDnsEntriesRepository>();
            var unitOfWorkProvider = Mock.Of<IUnitOfWorkProvider>();
            IDnsResolver resolver = new DnsResolver(dnsEntriesRepository, unitOfWorkProvider); 
            DnsRequest dnsRequest = new DnsRequest() { Name = "test", Type="TXT" };
            DnsResolutionResult result = resolver.Resolve(dnsRequest);
            result.DnsEntry.Should().BeNull();
        }

        [Test]
        public void Should_Resolve_Dns_Query_Because_Entry_Matches_Exactly()
        {
            var dnsEntriesRepository = Mock.Of<IDnsEntriesRepository>(mock => mock.FindDnsEntry(It.IsAny<IUnitOfWork>(), It.IsAny<DnsRequest>()) == new DnsEntry());
            var unitOfWorkProvider = Mock.Of<IUnitOfWorkProvider>();
            IDnsResolver resolver = new DnsResolver(dnsEntriesRepository, unitOfWorkProvider);
            DnsRequest dnsRequest = new DnsRequest() { Name = "test", Type = "TXT" };
            DnsResolutionResult result = resolver.Resolve(dnsRequest);
            result.DnsEntry.Should().NotBeNull();
        }
    }
}
