namespace Lecture1
{
    public class Person
    {
        (string UserName, string Password)[] Credentials = new[] { 
            (UserName: "Inigo.Montoya", Password: "YouKilledMyF@ther!")
        }; 

        public bool Login(string userName, string password)
        {
            return (userName, password) == Credentials[0];
        }
    }
}