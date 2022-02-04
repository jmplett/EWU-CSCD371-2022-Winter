using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class IJokeServiceTest
    {
        [TestMethod]
        public void GetJoke_NoParameters()
        {
            List<string> jokeList = new();
            jokeList.Add("Joke");
            
            Mock<IJokeService> mockJokeService = new();
            mockJokeService.Setup(x => x.GetJoke()).Returns(jokeList[0]);

            Assert.AreEqual<string>("Joke", mockJokeService.Object.GetJoke());
        }
    }
}
