using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPingProcess
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RunTaskAsync_Success()
        {
            //test method to test PingProcess.RunTaskAsync() using "localhost"
            //Do NOT use async/await in this implementation.
        }

        public void RunAsync_UsingTaskReturn_Success()
        {
            //test method to test PingProcess.RunAsync() using "localhost" without using async/await.
        }

        /* not yet implemented
        async public Task RunAsync_UsingTpl_Success()
        {
            // test method to test PingProcess.RunAsync() using "localhost" but this time DO using async/ await.
            
        }
        */


    }

}