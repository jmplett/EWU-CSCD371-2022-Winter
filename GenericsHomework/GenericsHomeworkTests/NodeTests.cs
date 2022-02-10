using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomeworkTests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void SimpleTest_CreateNode_Success()
        {
            Node<String> node = new("Hello");
            Assert.AreEqual(1, node.Size);
        }

        [TestMethod]
        public void SimpleTest_CreateNewNode_ToStringReturnsCorrectToString()
        {
            Node<String> node = new("Hello");
            Assert.AreEqual("Hello", node.Value);
        }

        [TestMethod]
        public void SimpleTest_NodeExists_ReturnsTrue()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");
            node.Append("Moon");
            node.Append("Mines");
            node.Append("Spys");

            node.Exists("Pie");
            node.Exists("Moon");
            node.Exists("Mines");
            node.Exists("Spys");
        }

        [TestMethod]
        public void SimpleTest_NodeDoesntExists_ReturnsFalse()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");
            node.Append("Moon");
            node.Append("Mines");
            node.Append("Spys");

            Assert.IsFalse(node.Exists("Justin"));
        }


        [TestMethod]
        public void SimpleTest_CreateLinkedNodes_NextReturnsToStringOfSecondNode()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");

            Assert.AreEqual("Pie", node.Next.Value);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SimpleTest_AddingNewNodeThatIsSameAsExistingNode_ThrowsExcpetion()
        {
            Node<String> node = new("Node 1");
            node.Append("Node 1");
        }

        [TestMethod]
        public void SimpleTest_ClearAllButHead_ReturnsSizeOfOne()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");


            node.Clear();

            Assert.AreEqual(1, node.Size);
        }
    }
}