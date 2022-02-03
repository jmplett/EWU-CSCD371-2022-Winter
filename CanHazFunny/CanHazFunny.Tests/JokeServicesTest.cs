using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace CanHazFunny.Tests
{
	[TestClass]
	public class JokeServicesTest
	{
		[TestMethod]
		public void JokeService_GetJokeOfTypeString_Success()
		{
			JokeService jokeService = new JokeService();
			string joke = jokeService.GetJoke();
			Assert.IsInstanceOfType(joke, typeof(string));
        }
	}

}

