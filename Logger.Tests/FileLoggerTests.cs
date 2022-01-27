using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void Test_CreateFileLoggerLog_SuccessfulMatchingLog()
        {
            if (File.Exists("FileLoggerTestFile.txt"))
            {
                File.Delete("FileLoggerTestFile.txt");
            }
            
            FileLogger logger = new("FileLoggerTestFile.txt");
            logger.ClassName = "TestLogger";
            logger.Log(LogLevel.Debug, "TestLog");
            logger.Log(LogLevel.Error, "Pie");
            logger.Log(LogLevel.Information, "I Don't Have Any Info");
            logger.Log(LogLevel.Warning, "Well I Found This");

            string[] lines = File.ReadAllLines("FileLoggerTestFile.txt");
            Assert.AreEqual(lines.Length, 4);
            Assert.AreEqual(lines[0], $"{DateTime.Now.ToString()} TestLogger Debug: TestLog");
            Assert.AreEqual(lines[1], $"{DateTime.Now.ToString()} TestLogger Error: Pie");
            Assert.AreEqual(lines[2], $"{DateTime.Now.ToString()} TestLogger Information: I Don't Have Any Info");
            Assert.AreEqual(lines[3], $"{DateTime.Now.ToString()} TestLogger Warning: Well I Found This");
        }
    }
}
