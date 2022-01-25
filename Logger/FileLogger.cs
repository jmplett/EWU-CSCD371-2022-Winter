using System;
using System.IO;

namespace Logger
{
	public class FileLogger:BaseLogger
	{
		public FileLogger(String filePath)
		{
            FilePath = filePath;
		}

        public string FilePath { get; }

        public override void Log(LogLevel logLevel, string message)
        {
            using StreamWriter logFile = new(FilePath);
            string currentTime = DateTime.Now.ToString();
            logFile.WriteLine($"{currentTime} {ClassName} {logLevel}: {message}");
        }
    }
}

