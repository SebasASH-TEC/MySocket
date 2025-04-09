using System.Net;
using System.Net.Sockets;
using System.Text;
using MySocket.Interfaces;

namespace MySocket.Core
{
    public class SocketServer : ISocketServer
    {
        private TcpListener _listener;
        private bool _running;
        private IMessageHandler _handler;

        public void Start(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            _running = true;

            Task.Run(() => AcceptClientsAsync());
        }

        private async Task AcceptClientsAsync()
        {
            while (_running)
            {
                var client = await _listener.AcceptTcpClientAsync();
                _ = Task.Run(() => HandleClientAsync(client));
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            using var stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int read = await stream.ReadAsync(buffer, 0, buffer.Length);
            string message = Encoding.UTF8.GetString(buffer, 0, read);

            _handler?.HandleMessage(message, stream);
        }

        public void Stop()
        {
            _running = false;
            _listener.Stop();
        }

        public void SetMessageHandler(IMessageHandler handler)
        {
            _handler = handler;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
