using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SimpleTest_WithNullJokeService_ThrowsException() => new Jester(null, new WriteLine());

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SimpleTest_WithNullWriteLine_ThrowsException() => new Jester(new JokeService(), null);

        [TestMethod]
        public void TellJoke_ReturnString_SucessGetString()
        {

        }


    }


}
