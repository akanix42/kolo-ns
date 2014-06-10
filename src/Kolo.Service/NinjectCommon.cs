using Kolo.Core.DataAccess;
using Kolo.Core.DataAccess.Repositories;
using Kolo.Core.Services;
using Kolo.Service.Services;
using Ninject;

namespace Kolo.Service
{
    public static class NinjectCommon
    {
        public static IKernel Kernel { get; set; }

        public static void Start()
        {
            Kernel = CreateKernel();
        }
        
      
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWorkProvider>().To<NPocoUnitOfWorkProvider>();
            kernel.Bind<IDnsEntriesRepository>().To<DnsEntriesRepository>();
            kernel.Bind<IForwardingServersRepository>().To<ForwardingServersRepository>();

            kernel.Bind<IDnsResolver>().To<DnsResolver>();
            kernel.Bind<IDnsQueryHandler>().To<DnsQueryHandler>();
            
        }        
    }
}
