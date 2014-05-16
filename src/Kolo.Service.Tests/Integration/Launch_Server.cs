using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ARSoft.Tools.Net.Dns;
using FluentAssertions;
using NUnit.Framework;

namespace Kolo.Service.Tests.Integration
{
    [TestFixture]
    class Launch_Server
    {
        [Test]
        public void Launch()
        {
           // Kolo.Service.Program.Main(new string[0]);
            ARecord aRecord=null;
            var client = new DnsClient(IPAddress.Loopback, (int)TimeSpan.FromSeconds(2).TotalMilliseconds);
            DnsMessage dnsMessage = client.Resolve("test.com", RecordType.A);
            if ((dnsMessage == null) || ((dnsMessage.ReturnCode != ReturnCode.NoError) && (dnsMessage.ReturnCode != ReturnCode.NxDomain)))
            {
                throw new Exception("DNS request failed");
            }
            else
            {
                foreach (DnsRecordBase dnsRecord in dnsMessage.AnswerRecords)
                {
                    aRecord = dnsRecord as ARecord;
                    if (aRecord != null)
                    {
                        Console.WriteLine(aRecord.Address.ToString());
                    }
                }
            }
            aRecord.Should().NotBeNull();
        }
    }
}
