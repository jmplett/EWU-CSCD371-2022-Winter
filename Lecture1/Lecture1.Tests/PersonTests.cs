using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lecture1.Tests
{
    [TestClass]
    public class PersonTests
    {
        Person Person = new();
        string UserName = "inigo.Montoya";
        string Password = "";

        [TestInitialize]
        public void Initalize()
        {
            Password = "YouKilledMyFather";
        }

        [TestMethod]
        public void Login_GivenValidUserNameAndPassword_Success()
        {
            Person.Login(UserName , Password);
            bool success = Person.Login(UserName, Password);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Login_GivenInvalidPassword_Failure()
        {
            string password = "InvalidPassword";
            Person.Login(UserName, password);
            bool result = Person.Login(UserName, password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Login_GivenInvalidUsername_Failure()
        {
            UserName = "MarkMichaelis";
            bool result = Person.Login(UserName, Password);
            Assert.IsFalse(result);
        }
    }
}