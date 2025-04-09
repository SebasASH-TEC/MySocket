namespace MySocket.Utilities
{
    public static class RetryPolicy
    {
        public static async Task ExecuteAsync(Func<Task> action, int maxRetries = 5, int delayMs = 300)
        {
            int attempts = 0;
            while (true)
            {
                try
                {
                    await action();
                    break;
                }
                catch
                {
                    attempts++;
                    if (attempts >= maxRetries) throw;
                    await Task.Delay(delayMs);
                }
            }
        }
    }
}
