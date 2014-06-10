using NPoco;

namespace Kolo.Core.Models
{
    public class DnsEntry
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string IpV4 { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    }
}