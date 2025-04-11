namespace MySocket.Interfaces
{
    // / Interfaz para manejar el socket, su inicio y fin
    public interface ISocketServer : IDisposable
    {
        void Start(int port);
        void Stop();
        void SetMessageHandler(IMessageHandler handler);
    }
}
