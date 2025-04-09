namespace MySocket.Interfaces
{
    public interface ISocketClient : IDisposable
    {
        Task ConnectAsync(string host, int port);
        Task SendAsync(string message);
        Task<string> ReceiveAsync();
        void Disconnect();
    }
}
