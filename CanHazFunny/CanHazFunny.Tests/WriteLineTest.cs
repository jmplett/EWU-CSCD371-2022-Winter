using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class WriteLineTest
    {
        [TestMethod]
        public void SimpleTest_WriteLine_WritesLine()
        {
            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            WriteLine.PrintToConsole("Inigo Montoya");

            Assert.AreEqual<string>("Inigo Montoya", stringWriter.ToString());

        }
    }

}