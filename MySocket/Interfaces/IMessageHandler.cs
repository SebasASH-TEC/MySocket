using System.Net.Sockets;

namespace MySocket.Interfaces
{
    public interface IMessageHandler
    {
        void HandleMessage(string message, NetworkStream stream);
    }
}
