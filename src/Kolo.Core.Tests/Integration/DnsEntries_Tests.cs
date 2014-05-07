using FluentAssertions;
using Kolo.Service.Tests.Integration;
using NUnit.Framework;

namespace Kolo.Core.Tests.Integration
{
    [TestFixture]
    class DnsEntries_Tests
    {
        [Test]
        public void Should_Create_DNS_Entry()
        {
            var dnsEntry = new DnsEntry()
            {
                Type = "TXT",
                Name = "test",
                IpV4 = "192.168.1.1",
            };

            IUnitOfWorkProvider unitOfWorkProvider = new NPocoUnitOfWorkProvider();
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                IDnsEntriesRepository repository = new DnsEntriesRepository();

                var id = repository.AddDnsEntry(uow, dnsEntry);

                uow.Commit();

                id.Should().BeGreaterThan(0, "because a valid ID should have been returned when the dns entry was created.");
                dnsEntry.Id.Should().BeGreaterThan(0, "because a valid ID should have been returned when the dns entry was created.");
            }
        }
    }
}
