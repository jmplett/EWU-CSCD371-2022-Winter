using System;
using System.Collections.Generic;
using System.Linq;

namespace MultithreadingStuff.Tests;

[TestClass]
public class ParrallelTests
{
    [TestMethod]
    public void MyTestMethod()
    {
        
        IEnumerable<string> members = 
            typeof(Enumerable).GetMembers().Select(item=>item.Name);

        IEnumerable<string> membersBeginningWithS =
            members.Where(item => item[0] == 'S');

       
    }
}
