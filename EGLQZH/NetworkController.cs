using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TicTacToe {
    static class NetworkController {
        static readonly UdpClient udpClient = new();
        static readonly CancellationTokenSource cts = new();

        public static async Task<List<IPAddress>> Discover() {
            await SendMessage("DISCOVER");

            return await ListenToDiscover();
        }

        private static async Task<List<IPAddress>> ListenToDiscover() {
            IPAddress localIP = LocalIPAddress();

            List<IPAddress> addresses = new();
            var listen = Task.Run(async () => {
                while (!cts.IsCancellationRequested) {
                    var (message, remoteAddress) = await ReceiveMessage();
                    //Trace.WriteLine($"Received message from {remoteAddress}: '{message}'");
                    if (!addresses.Contains(remoteAddress)) {
                        addresses.Add(remoteAddress);

                        await SendMessage("ACK", remoteAddress);
                        GameController.renderer.DrawDiscover(addresses);
                    }
                }
            });

            var waitKey = Task.Run(() => {
                Input.WaitKey(ConsoleKey.Escape);
                cts.Cancel();
            });

            await Task.WhenAny(listen, waitKey);
            return addresses;
        }

        private static async Task<(string, IPAddress)> ReceiveMessage() {
            var recv = await udpClient.ReceiveAsync(cts.Token);
            var recvMessage = Encoding.UTF8.GetString(recv.Buffer);
            IPAddress recvAddress = recv.RemoteEndPoint.Address;

            return (recvMessage, recvAddress);
        }

        private static async Task<int> SendMessage(string msg, IPAddress? to = null) {
            udpClient.Client.Bind(new IPEndPoint(to ?? IPAddress.Any, port));

            var discoverMessage = Encoding.UTF8.GetBytes(msg);
            // TODO: Get network's broadcast address
            return await udpClient.SendAsync(discoverMessage, discoverMessage.Length, "255.255.255.255", port);
        }

        private static IPAddress LocalIPAddress() {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) {
                GameController.renderer.DrawError("Please connect to a network before playing!");
                Environment.Exit(1);
            }

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            return host
                .AddressList
                .First(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
        private const ushort port = 32555;
    }
}
