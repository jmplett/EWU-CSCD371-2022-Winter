namespace Logger
{
    public class LogFactory
    {
        private string? _FilePath;

        public string? FilePath { get => _FilePath;  }

        public BaseLogger? CreateLogger(string className)
        {
            if (_FilePath is null)   
                return null;

            FileLogger fileLogger = new(_FilePath!)
            {
                ClassName = className
            };

            return fileLogger;

        }

        public void ConfigureFileLogger(string FilePath)
        {
            _FilePath = FilePath;
        }
    }
}
