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
            LogFactory logFactory = new();
            logFactory.ConfigureFileLogger("filepath");

            BaseLogger logger = logFactory.CreateLogger(nameof(LogFactoryTests));

            Assert.AreEqual("FileLogger", logger.GetType().Name);
        }

       [TestMethod]
       public void CreateLogger_WithoutValidFilePath_ReturnsNull()
        {
            LogFactory logFactory = new();
            var logger = logFactory.CreateLogger(nameof(LogFactoryTests));
            Assert.IsNull(logger);

        }

    }
}
