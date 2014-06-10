using NPoco;

namespace Kolo.Core.Models
{
    public class ForwardingServer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string IpV4 { get; set; }
    }
}