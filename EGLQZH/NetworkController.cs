using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TicTacToe {
    static class NetworkController {
        static readonly UdpClient udpClient = new();
        static readonly CancellationTokenSource cts = new();

        public static async Task<List<IPAddress>> Discover() {
            await SendBroadcast();

            return await ListenToDiscover();
        }

        private static async Task<List<IPAddress>> ListenToDiscover() {
            

            List<IPAddress> addresses = new();
            var listen = Task.Run(async () => {
                while (!cts.IsCancellationRequested) {
                    var recv = await udpClient.ReceiveAsync(cts.Token);
                    addresses.Add(recv.RemoteEndPoint.Address);
                }
            });

            var waitKey = Task.Run(() => {
                Input.WaitKey(ConsoleKey.Escape);
                cts.Cancel();
            });

            await Task.WhenAny(listen, waitKey);
            return addresses;
        }

        private static async Task<int> SendBroadcast() {
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, port));

            var discoverMessageText = "DISCOVER";
            var discoverMessage = Encoding.UTF8.GetBytes(discoverMessageText);
            // TODO: Get network's broadcast address
            return await udpClient.SendAsync(discoverMessage, discoverMessage.Length, "255.255.255.255", port);
        }

        private static IPAddress? LocalIPAddress() {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) {
                return null;
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
        private const ushort port = 32555;
    }
}
