
namespace eShopApi.Services.Implementations
{
    public class LoggerService<T>(ILogger<T> logger) : ILoggerService
    {
        private readonly ILogger<T> _logger = logger;

        public void LogDebug(string message, params object[] args)
        {
            _logger.LogDebug(message, args);
        }
        public void LogInfo(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }
        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
        public void LogError(Exception exception, string message, params object[] args)
        {
            _logger.LogError(exception, message, args);
        }
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
        public void LogCritical(Exception exception, string message, params object[] args)
        {
            _logger.LogCritical(exception, message, args);
        }
        public void LogCritical(string message, params object[] args)
        {
            _logger.LogCritical(message, args);
        }
    }
}