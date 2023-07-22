using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.TCP;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.IPv4.UDP.DNS;
using System.Text;

namespace BootNET.Network
{
    /// <summary>
    /// Basic network manager implementation using DNS, DHCP and TCP.
    /// </summary>
    public static class NetworkManager
    {
        #region Methods
        /// <summary>
        /// Initialize network using <see cref="DHCPClient"/>
        /// </summary>
        /// <param name="DNS">DNS to connect. If you don't know, just set new(1, 1, 1, 1) wich is the CloudFlare DNS.</param>
        public static void Initialize(Address DNS)
        {
            using (var xClient = new DHCPClient())
            {
                xClient.SendDiscoverPacket();
            }
            DNSClient.Connect(DNS);
        }
        /// <summary>
        /// Download a file.
        /// </summary>
        /// <param name="url">URL of the file.</param>
        /// <returns></returns>
        public static string DownloadFile(string url)
        {
            var dnsClient = new DnsClient();
            var tcpClient = new TcpClient(80);

            dnsClient.Connect(DNSConfig.DNSNameservers[0]);
            dnsClient.SendAsk(url);
            Address address = dnsClient.Receive();
            dnsClient.Close();

            tcpClient.Connect(address, 80);

            string httpget = "GET / HTTP/1.1\r\n" +
                             "User-Agent: Wget (CosmosOS)\r\n" +
                             "Accept: */*\r\n" +
                             "Accept-Encoding: identity\r\n" +
                             "Host: " + url + "\r\n" +
                             "Connection: Keep-Alive\r\n\r\n";

            tcpClient.Send(Encoding.ASCII.GetBytes(httpget));

            var ep = new EndPoint(Address.Zero, 0);
            var data = tcpClient.Receive(ref ep);
            tcpClient.Close();

            string httpresponse = Encoding.ASCII.GetString(data);
            return httpresponse;
        }
        #endregion

        #region Fields
        public static DnsClient DNSClient;
        #endregion
    }
}
