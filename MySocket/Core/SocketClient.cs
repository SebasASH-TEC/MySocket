using System.Net.Sockets;
using System.Text;
using MySocket.Interfaces;

namespace MySocket.Core
{
    public class SocketClient : ISocketClient
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public async Task ConnectAsync(string host, int port)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(host, port);
            _stream = _client.GetStream();
        }

        public async Task SendAsync(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await _stream.WriteAsync(buffer, 0, buffer.Length);
        }

        public async Task<string> ReceiveAsync()
        {
            byte[] buffer = new byte[1024];
            int read = await _stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, read);
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
