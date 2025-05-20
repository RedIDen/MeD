namespace Core.Logging;

public interface ILogger
{
    Task Info(string context, string message);
    Task Error(string context, string message);
    Task Debug(string context, string message);
}
