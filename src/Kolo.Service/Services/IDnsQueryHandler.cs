using System.Net;
using ARSoft.Tools.Net.Dns;

namespace Kolo.Service.Services
{
    public interface IDnsQueryHandler
    {
        DnsMessageBase HandleQuery(DnsMessageBase message, IPAddress clientAddress, KeyRecordBase.ProtocolType protocol);
    }
}