namespace MySocket.Exceptions
{
    public class SocketTimeoutException : Exception
    {
        public SocketTimeoutException(string message) : base(message) { }
    }
}
