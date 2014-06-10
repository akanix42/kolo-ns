using System;
using System.Collections.Generic;
using AutoMapper;
using Kolo.Core.DataAccess.SQL.Models;
using Kolo.Core.Models;
using NPoco;
using DnsEntry = Kolo.Core.Models.DnsEntry;
using ForwardingServer = Kolo.Core.Models.ForwardingServer;

namespace Kolo.Core.DataAccess.Repositories
{
    public class ForwardingServersRepository : IForwardingServersRepository
    {
        public void DeleteAllEntries(IUnitOfWork uow)
        {
            uow.Db.Execute(new Sql()
                .Append("DELETE FROM forwarding_servers"));
        }

        public int AddFowardingServer(IUnitOfWork uow, ForwardingServer forwardingServer)
        {
            var mappedForwardingServer = Mapper.Map<SQL.Models.ForwardingServer>(forwardingServer);
            var id = Convert.ToInt32(uow.Db.Insert(mappedForwardingServer));
            Mapper.Map(mappedForwardingServer, forwardingServer);
            return id;
        }

        public void UpdateForwardingServer(IUnitOfWork uow, ForwardingServer forwardingServer)
        {
            uow.Db.Update(Mapper.Map<SQL.Models.ForwardingServer>(forwardingServer));
        }

        public ForwardingServer GetForwardingServer(IUnitOfWork uow, int forwardingServerId)
        {
            return Mapper.Map<Core.Models.ForwardingServer>(uow.Db.FirstOrDefault<DataAccess.SQL.Models.ForwardingServer>(
                new Sql().Append("WHERE Id = @forwardingServerId", new {forwardingServerId})));
        }

        public List<ForwardingServer> GetAllForwardingServers(IUnitOfWork uow)
        {
            return Mapper.Map<List<Core.Models.ForwardingServer>>(uow.Db.Fetch<SQL.Models.ForwardingServer>());
        }

        public void DeleteForwardingServer(IUnitOfWork uow, int forwardingServerId)
        {
            uow.Db.Delete(new Sql().Append("WHERE Id = @forwardingServerId", new {forwardingServerId}));
        }
    }
}