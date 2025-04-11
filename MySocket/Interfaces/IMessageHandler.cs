using System.Net.Sockets;

namespace MySocket.Interfaces
{
    /// Define una interfaz para manejar los mensajes recibidos
    public interface IMessageHandler
    {
        void HandleMessage(string message, NetworkStream stream);
    }
}
