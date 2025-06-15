

namespace eShopApi.Services.Implementations
{
    public interface ILoggerService
    {
        void LogDebug(string message, params object[] args);
        void LogInfo(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(Exception exception, string message, params object[] args);
        void LogError(string message, params object[] args);
        void LogCritical(Exception exception, string message, params object[] args);
        void LogCritical(string message, params object[] args);
    }
}