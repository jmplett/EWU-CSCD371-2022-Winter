using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            Random random = new Random();

            Mock<IJokeService> mockJokeService = new();
            mockJokeService.Setup(x => x.GetJoke()).Returns(jokeList[random.Next(jokeList.Count)]);

            Assert.AreEqual<string>("Joke", mockJokeService.Object.GetJoke());
        }
    }
}
