using System;
namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger? baseLogger, string message, params object[] parameters)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                string logMessage = message;
                if (parameters.Length > 0)
                {
                    logMessage = String.Format(logMessage, parameters);
                }
                logger.Log(LogLevel.Error, logMessage);
            }
        }

        public static void Warning(this BaseLogger? baseLogger, string message, params object[] parameters)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                string logMessage = String.Format(message, parameters);
                baseLogger.Log(LogLevel.Warning, logMessage);
            }
        }

        public static void Information(this BaseLogger? baseLogger, string message, params object[] parameters)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                string logMessage = String.Format(message, parameters);
                baseLogger.Log(LogLevel.Information, logMessage);
            }
        }

        public static void Debug(this BaseLogger? baseLogger, string message, params object[] parameters)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                string logMessage = String.Format(message, parameters);
                baseLogger.Log(LogLevel.Debug, logMessage);
            }
        }
    }
}
