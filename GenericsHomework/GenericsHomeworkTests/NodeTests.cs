using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomeworkTests
{
    [TestClass]
    public class NodeTests
    {
        [Ignore]
        [TestMethod]
        public void SimpleTest_CreateNode_Success()
        {
            NodeTests node = new();
            Assert.AreEqual(node, 0);//need to a way to get size
        }

        [Ignore]
        [TestMethod]
        public void SimpleTest_AppendNode_Success()
        {

        }

        [Ignore]
        [TestMethod]
        public void SimpleTest_ClearNode_Success()
        {

        }

        [Ignore]
        [TestMethod]
        public void SimpleTest_NodeExists_Success()
        {

        }
    }
}