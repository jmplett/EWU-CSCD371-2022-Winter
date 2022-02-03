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
            WriteLine writeLine = new();

#pragma warning disable CA1303 // The string is only used for testing.
            writeLine.PrintToConsole("Inigo Montoya");
#pragma warning restore CA1303 // The string is only used for testing.

            Assert.AreEqual<string>("Inigo Montoya", stringWriter.ToString().TrimEnd());
            
            stringWriter.Dispose();
        }
    }

}