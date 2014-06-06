using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ARSoft.Tools.Net.Dns;
using Kolo.Core.Services;
using Kolo.Service.Services;
using Ninject;

namespace Kolo.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Core.DataAccess.SQL.ModelMappings().Create();

            var kernel = NinjectCommon.CreateKernel();
            var dnsQueryHandler = kernel.Get<IDnsQueryHandler>();
            using (var server = new DnsServer(IPAddress.Any, 10, 10, dnsQueryHandler.HandleQuery ))
            {
                server.Start();
                Console.WriteLine("Press enter to stop server");
                Console.ReadLine();
            }
        }
    }
}
