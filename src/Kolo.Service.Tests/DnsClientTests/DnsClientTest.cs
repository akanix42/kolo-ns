using System;
using System.Net;
using ARSoft.Tools.Net.Dns;
using NUnit.Framework;

namespace Kolo.Service.Tests.DnsClientTests
{
    class DnsClientTest
    {
        [Test]
        public void GetAddresses()
        {
            DnsClient dnsClient = DnsClient.Default;
            dnsClient = new DnsClient(IPAddress.Parse("192.168.2.254"), 2000);
            DnsMessage dnsMessage = dnsClient.Resolve("www.google.com", RecordType.A);
            if ((dnsMessage == null) || ((dnsMessage.ReturnCode != ReturnCode.NoError) && (dnsMessage.ReturnCode != ReturnCode.NxDomain)))
            {
                throw new Exception("DNS request failed");
            }
            else
            {
                foreach (DnsRecordBase dnsRecord in dnsMessage.AnswerRecords)
                {
                    ARecord aRecord = dnsRecord as ARecord;
                    if (aRecord != null)
                    {
                        Console.WriteLine(aRecord.Address.ToString());
                    }
                }
            }
        }
    }
}
