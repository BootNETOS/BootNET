using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.IPv4.UDP.DNS;

namespace BootNET.Network
{
    public static class NetworkManager
    {
        #region Methods
        public static void Initialize(Address DNS)
        {
            using (var xClient = new DHCPClient())
            {
                xClient.SendDiscoverPacket();
            }
            DNSClient.Connect(DNS);
        }
        #endregion
        #region Fields
        public static DnsClient DNSClient;
        #endregion
    }
}
