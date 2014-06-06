using FluentAssertions;
using Kolo.Core.DataAccess;
using Kolo.Core.DataAccess.Repositories;
using Kolo.Core.Models;
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
                repository.DeleteAllEntries(uow);

                var id = repository.AddDnsEntry(uow, dnsEntry);

                uow.Commit();

                id.Should().BeGreaterThan(0, "because a valid ID should have been returned when the dns entry was created.");
                dnsEntry.Id.Should().BeGreaterThan(0, "because a valid ID should have been returned when the dns entry was created.");
            }
        }

        [Test]
        public void Should_Update_DNS_Entry()
        {
            var dnsEntry = new DnsEntry()
            {
                Type = "TXT",
                Name = "testing",
                IpV4 = "192.168.1.1",
            };

            IUnitOfWorkProvider unitOfWorkProvider = new NPocoUnitOfWorkProvider();
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                IDnsEntriesRepository repository = new DnsEntriesRepository();
                repository.DeleteAllEntries(uow);

                var id = repository.AddDnsEntry(uow, dnsEntry);

                dnsEntry.Name = "test2";
                repository.UpdateDnsEntry(uow, dnsEntry);
                DnsEntry updatedEntry = repository.GetDnsEntry(uow, dnsEntry.Id);
                updatedEntry.Name.Should().Be(dnsEntry.Name);

            }
        }

        [Test]
        public void Should_Find_DNS_Entry()
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

                repository.DeleteAllEntries(uow);
                var id = repository.AddDnsEntry(uow, dnsEntry);
               
                uow.Commit();

                repository.FindDnsEntry(uow, new DnsRequest() {Name = dnsEntry.Name, Type = dnsEntry.Type}).Id.Should().Be(id);
            }
        }
    }
}
