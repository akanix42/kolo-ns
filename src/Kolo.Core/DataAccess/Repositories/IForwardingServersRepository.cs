using System.Collections.Generic;
using Kolo.Core.DataAccess.SQL.Models;
using Kolo.Core.Models;
using DnsEntry = Kolo.Core.Models.DnsEntry;
using ForwardingServer = Kolo.Core.Models.ForwardingServer;

namespace Kolo.Core.DataAccess.Repositories
{
    public interface IForwardingServersRepository
    {
        void DeleteAllEntries(IUnitOfWork uow);
        int AddFowardingServer(IUnitOfWork uow, ForwardingServer forwardingServer);
        void UpdateForwardingServer(IUnitOfWork uow, ForwardingServer forwardingServer);
        ForwardingServer GetForwardingServer(IUnitOfWork uow, int forwardingServerId);
        List<ForwardingServer> GetAllForwardingServers(IUnitOfWork uow);
        void DeleteForwardingServer(IUnitOfWork uow, int forwardingServerId);
    }
}