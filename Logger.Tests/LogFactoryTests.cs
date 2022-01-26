using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_WithValidFilePath_ReturnsFileLogger()
        {
            var logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("filepath");

            var logger = logFactory.CreateLogger(nameof(LogFactoryTests));

            Assert.AreEqual("FileLogger", logger.GetType().Name);
        }
    }
}
