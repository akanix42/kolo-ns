using System.Net;
using System.Net.Sockets;
using ARSoft.Tools.Net.Dns;

namespace Kolo.Service.Services
{
    public interface IDnsQueryHandler
    {
        DnsMessageBase HandleQuery(DnsMessageBase message, IPAddress clientAddress, ProtocolType protocol);
    }
}