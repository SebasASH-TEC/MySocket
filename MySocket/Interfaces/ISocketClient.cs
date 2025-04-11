namespace MySocket.Interfaces
{
    // Interfaz para manejar la comunicacion del socket
    public interface ISocketClient : IDisposable
    {
        Task ConnectAsync(string host, int port);
        Task SendAsync(string message);
        Task<string> ReceiveAsync();
        void Disconnect();
    }
}
