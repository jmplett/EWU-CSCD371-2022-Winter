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
            string currentTime = DateTime.Now.ToString();
            File.AppendAllText(FilePath, $"{currentTime} {ClassName} {logLevel}: {message}");
        }
    }
}

