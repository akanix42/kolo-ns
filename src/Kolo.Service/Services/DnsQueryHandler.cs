using System.Linq;
using System.Net;
using System.Net.Sockets;
using ARSoft.Tools.Net.Dns;
using Kolo.Core.Models;
using Kolo.Core.Services;

namespace Kolo.Service.Services
{
    public class DnsQueryHandler : IDnsQueryHandler
    {
        private readonly IDnsResolver dnsResolver;

        public DnsQueryHandler(IDnsResolver dnsResolver)
        {
            this.dnsResolver = dnsResolver;
        }

        public DnsMessageBase HandleQuery(DnsMessageBase message, IPAddress clientAddress, ProtocolType protocol)
        {
            var query = message as DnsMessage;
            if (query == null)
                message.ReturnCode = ReturnCode.ServerFailure;
            else
                ProcessQuery(query);

            return message;
        }

        private void ProcessQuery(DnsMessage query)
        {
            if (!query.Questions.Any())
            {
                query.ReturnCode = ReturnCode.ServerFailure;
                return;
            }

            ProcessQuestion(query, query.Questions[0]);
        }

        private void ProcessQuestion(DnsMessage message, DnsQuestion dnsQuestion)
        {
            var dnsRequest = new DnsRequest() { Name = dnsQuestion.Name, Type = dnsQuestion.RecordType.ToString() };
            var result = dnsResolver.Resolve(dnsRequest);
            if (result.DnsEntry == null)
            {
                message.ReturnCode = ReturnCode.NxDomain;
                return;
            }

            message.AnswerRecords.Add(new ARecord(result.DnsEntry.Name, 3600, IPAddress.Parse(result.DnsEntry.IpV4)));
        }
    }
}