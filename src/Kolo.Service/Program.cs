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
            var kernel = NinjectCommon.CreateKernel();
            var dnsQueryHandler = kernel.Get<IDnsQueryHandler>();
            using (DnsServer server = new DnsServer(IPAddress.Any, 10, 10, dnsQueryHandler.HandleQuery ))
            {
                server.Start();
                Console.WriteLine("Press any key to stop server");
                Console.ReadLine();
            }
        }
    }
}
