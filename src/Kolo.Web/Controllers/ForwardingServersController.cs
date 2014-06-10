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
    public class ForwardingServersController : ApiController
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;
        private readonly IForwardingServersRepository forwardingServersRepository;

        public ForwardingServersController(IUnitOfWorkProvider unitOfWorkProvider, IForwardingServersRepository forwardingServersRepository)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.forwardingServersRepository = forwardingServersRepository;
        }

        // GET api/dnsentries
        public List<ForwardingServer> Get()
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                return forwardingServersRepository.GetAllForwardingServers(uow);
            }
        }

        // GET api/dnsentries/5
        public ForwardingServer Get(int id)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                return forwardingServersRepository.GetForwardingServer(uow, id);
            }
        }

        // POST api/dnsentries
        public void Post(ForwardingServer forwardingServer)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                forwardingServersRepository.AddFowardingServer(uow, forwardingServer);
                uow.Commit();
            }
        }

        // PUT api/dnsentries/5
        public void Put(int id, ForwardingServer forwardingServer)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                forwardingServersRepository.UpdateForwardingServer(uow, forwardingServer);
                uow.Commit();
            }
        }

        // DELETE api/dnsentries/5
        public void Delete(int id)
        {
            using (var uow = unitOfWorkProvider.GetUnitOfWork())
            {
                forwardingServersRepository.DeleteForwardingServer(uow, id);

                uow.Commit();
            }
        }
    }
}
