namespace MySocket.Interfaces
{
    public interface ISocketServer : IDisposable
    {
        void Start(int port);
        void Stop();
        void SetMessageHandler(IMessageHandler handler);
    }
}
