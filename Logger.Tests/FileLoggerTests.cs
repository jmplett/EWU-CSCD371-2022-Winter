using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        public void SimpleTest_CreateFileLogger_SuccessNotReturningNull()
        {
            FileLogger logger = new("FileLoggerTestFile.txt");
            Assert.AreNotEqual(logger, null);
        }

        [TestMethod]
        public void SimpleTest_CreateFileLogger_SuccessGetFileName()
        {
            FileLogger logger = new("FileLoggerTestFile.txt");
            Assert.AreEqual(logger.FilePath, "FileLoggerTestFile.txt");
        }

        [TestMethod]
        public void SimpleTest_CreateFileLoggerLog_SuccessGetFileName()
        {
            if (File.Exists("FileLoggerTestFile.txt"))
            {
                File.Delete("FileLoggerTestFile.txt");
            }
            
            FileLogger logger = new("FileLoggerTestFile.txt");
            logger.Log(LogLevel.Debug, "TestLog");

            string[] lines = File.ReadAllLines("FileLoggerTestFile.txt");
            Assert.AreEqual(lines.Length, 1);
            //Assert.AreEqual(lines[0], "");
        }

    }
}
