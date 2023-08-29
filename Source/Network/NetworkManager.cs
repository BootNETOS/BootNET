using Cosmos.System.Network.IPv4.UDP.DHCP;

namespace BootNET.Network
{
    /// <summary>
    /// Simple Network Manager using Cosmos Network Stack
    /// </summary>
    public static class NetworkManager
    {
        /// <summary>
        /// Connect to internet using DHCP.
        /// </summary>
        public static DHCPClient DHCP;
        public static void Initialize()
        {
            DHCP = new();
            DHCP.SendDiscoverPacket();
        }
    }
}
