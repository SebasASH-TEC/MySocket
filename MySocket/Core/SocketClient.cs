using System.Net.Sockets;
using System.Text;
using MySocket.Interfaces;

namespace MySocket.Core
{
    public class SocketClient : ISocketClient
    {
        // Cliente TCP para comunicacion
        private TcpClient _client; 
        private NetworkStream _stream; 

        // Se conecta al puerto y direccion especificada de forma asincrona
        public async Task ConnectAsync(string host, int port)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(host, port); 
            _stream = _client.GetStream(); 
        }

        // Envia un mensaje codificado al servidor conectado
        public async Task SendAsync(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message); 
            await _stream.WriteAsync(buffer, 0, buffer.Length); 
        }

        // Recibe el mensaje de forma asincrona del server, y lo convierte a string
        public async Task<string> ReceiveAsync()
        {
            byte[] buffer = new byte[1024]; 
            int read = await _stream.ReadAsync(buffer, 0, buffer.Length); 
            return Encoding.UTF8.GetString(buffer, 0, read); 
        }

        // Permite desconectarse del server
        public void Disconnect()
        {
            _stream?.Close(); 
            _client?.Close(); 
        }

        // Llama a Disconnect
        public void Dispose()
        {
            Disconnect(); 
        }
    }
}
