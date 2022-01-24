using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
