using FluentAssertions;
using Kolo.Core.DataAccess;
using Kolo.Core.DataAccess.Repositories;
using Kolo.Core.DataAccess.SQL;
using Kolo.Core.DataAccess.SQL.Models;
using Kolo.Core.Models;
using NUnit.Framework;
using DnsEntry = Kolo.Core.Models.DnsEntry;
using ForwardingServer = Kolo.Core.Models.ForwardingServer;

namespace Kolo.Core.Tests.Integration
{
    [TestFixture]
    class ForwardingServers_Tests
    {
        [Test]
        public void Should_Create_Forwarding_Server_Entry()
        {
            new ModelMappings().Create();
            var forwardingServer = new ForwardingServer()
            {
                Name = "test",
                IpV4 = "192.168.1.1",
            };

            IUnitOfWorkProvider unitOfWorkProvider = new NPocoUnitOfWorkProvider();
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                IForwardingServersRepository repository = new ForwardingServersRepository();
                repository.DeleteAllEntries(uow);

                var id = repository.AddFowardingServer(uow, forwardingServer);

                uow.Commit();

                id.Should().BeGreaterThan(0, "because a valid ID should have been returned when the entry was created.");
                forwardingServer.Id.Should().Be(id, "because a valid ID should have been returned when the entry was created.");
            }
        }

        [Test]
        public void Should_Update_Forwarding_Server_Entry()
        {
            new ModelMappings().Create();
            var forwardingServer = new ForwardingServer()
            {
                Name = "testing",
                IpV4 = "192.168.1.1",
            };

            IUnitOfWorkProvider unitOfWorkProvider = new NPocoUnitOfWorkProvider();
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                IForwardingServersRepository repository = new ForwardingServersRepository();
                repository.DeleteAllEntries(uow);

                var id = repository.AddFowardingServer(uow, forwardingServer);

                forwardingServer.Name = "test2";
                repository.UpdateForwardingServer(uow, forwardingServer);
                var updatedEntry = repository.GetForwardingServer(uow, forwardingServer.Id);
                updatedEntry.Name.Should().Be(forwardingServer.Name);

            }
        }


    }
}
