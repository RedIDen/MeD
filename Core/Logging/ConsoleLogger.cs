namespace Core.Logging;

public class ConsoleLogger : ILogger
{
    public Task Debug(string context, string message)
    {
        Console.WriteLine($"{context}: {message}");
        return Task.CompletedTask;
    }

    public Task Error(string context, string message)
    {
        Console.WriteLine($"{context}: {message}");
        return Task.CompletedTask;
    }

    public Task Info(string context, string message)
    {
        Console.WriteLine($"{context}: {message}");
        return Task.CompletedTask;
    }
}
