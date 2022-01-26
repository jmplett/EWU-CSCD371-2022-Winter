namespace Logger
{
    public abstract class BaseLogger
    {
        public string? ClassName { get; set; } = "BaseLogger";

        public abstract void Log(LogLevel logLevel, string message);
    }
}
