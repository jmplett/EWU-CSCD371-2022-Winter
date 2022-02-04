using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;

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
        public void SimpleTest_CreateJester_Success()
        {
            Jester jester = new Jester(new JokeService(), new WriteLine());
            Assert.IsInstanceOfType(jester, typeof(Jester));
        }


        [TestMethod]
        public void GetJoke_WithRemovalOfChuckNorris_Success()
        {
            Mock<IJokeService> mockJokeService = new();
            mockJokeService
                .SetupSequence(x => x.GetJoke())
                .Returns("Chuck... Chuck... Chuck...")
                .Returns("Why another Chuck Norris")
                .Returns("My Last name is Norris")
                .Returns("Valid Joke");

            WriteLine writeLine = new WriteLine(); 

            Jester jester = new(mockJokeService.Object, writeLine);


            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            jester.TellJoke();


            Assert.AreEqual<string>("Valid Joke", stringWriter.ToString().TrimEnd());

            stringWriter.Dispose();
        }

        [TestMethod]
        public void SimpleTest_ValidJokeGivenToT_Success()
        {
            List<string> jokeList = new();
            jokeList.Add("Valid Joke");
            Random random = new Random();

            Mock<IJokeService> mockJokeService = new();
            mockJokeService.Setup(x => x.GetJoke()).Returns(jokeList[random.Next(jokeList.Count)]);

            WriteLine writeLine = new WriteLine();

            Jester jester = new(mockJokeService.Object, writeLine);


            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);

            jester.TellJoke();


            Assert.AreEqual<string>("Valid Joke", stringWriter.ToString().TrimEnd());

            stringWriter.Dispose();
        }

    }
}
