using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomeworkTests
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "Naming Convention in tests")]
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void SimpleTest_CreateNewNode_ToStringReturnsCorrectToString()
        {
            Node<String> node = new("Hello");
            Assert.AreEqual("Hello", $"{node.Value}");
        }

        [TestMethod]
        public void SimpleTest_ForEach_EntersLoop()
        {
            Node<String> node = new("Hello");
            bool inLoop = false;
            foreach(var item in node)
            {
                inLoop = true;
            }
            Assert.IsTrue(inLoop);
        }

        [TestMethod]
        public void SimpleTest_NodeExists_ReturnsTrue()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");
            node.Append("Moon");
            node.Append("Mines");
            node.Append("Spys");

            Assert.IsTrue(node.Exists("Pie"));
            Assert.IsTrue(node.Exists("Moon"));
            Assert.IsTrue(node.Exists("Mines"));
            Assert.IsTrue(node.Exists("Spys"));
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
            Node<string> node = new("Node 1");
            node.Append("Pie");

            Assert.AreEqual<string>("Pie", node.Next.Value!);
        }

        [TestMethod]
        public void SimpleTest_CreateSingleNullNode_ValueIsNull()
        {
            Node<string> nodeString = new(null);
            Node<string[]> nodeStringArray = new(null);
            Node<Node<string>> nodeCollectionOfNodeCollectionString = new(null);

            Assert.IsNull(nodeString.Value);
            Assert.IsNull(nodeStringArray.Value);
            Assert.IsNull(nodeCollectionOfNodeCollectionString.Value);
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
            Node<int> node = new(1);
            node.Append(41);
            node.Append(42);
            node.Append(43);
            Node<int> next = node.Next;

            node.Clear();

            Assert.IsTrue(node.Exists(1));
            Assert.IsFalse(node.Exists(42));

            Assert.IsTrue(next.Exists(42));
            Assert.IsFalse(next.Exists(1));
        }

        [TestMethod]
        public void SimpleTest_CallToStringOnSingularNode_Success()
        {
            Node<String> node = new("Node 1");

            Assert.AreEqual("Node 1", node.ToString());
            Assert.AreEqual("Node 1", $"{node}");
        }

        [TestMethod]
        public void SimpleTest_CallToStringOnMultipleNodes_Success()
        {
            Node<String> node = new("Node 1");
            node.Append("Node 2");
            node.Append("Node 3");
            node.Append("Node 4");

            Assert.AreEqual("Node 1", $"{node}");
            node = node.Next;
            Assert.AreEqual("Node 4", $"{node}");
            node = node.Next;
            Assert.AreEqual("Node 3", $"{node}");
            node = node.Next;
            Assert.AreEqual("Node 2", $"{node}");
            node = node.Next;
            Assert.AreEqual("Node 1", $"{node}");
        }
        [TestMethod]
        public void SimpleTest_ClearAllButHead_SimpleReturn()
        {
            Node<String> node = new("Node 1");
            node.Clear();

            Assert.AreEqual("Node 1", $"{node}");
        }

        [TestMethod]
        public void SimpleTest_ForEach_IteratesCorrectNumberOfTimes()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");
            node.Append("Moon");
            node.Append("Mines");
            node.Append("Spys");
            node = node.Next;

            int count = 0;
            foreach (var item in node)
            {
                count++;
            }
            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void SimpleTest_ClearAllButHead_NextReturnsCorrectSize()
        {
            Node<String> node = new("Node 1");
            node.Append("Pie");
            node.Append("Moon");
            node.Append("Mines");
            node.Append("Spys");
            Node<String> next = node.Next;

            node.Clear();

            int count = 0;
            foreach (var item in node)
            {
                count++;
            }
            Assert.AreEqual(1, count);

            count = 0;
            foreach (var item in next)
            {
                count++;
            }

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void SimpleTest_ForEachChildItems_ReturnsLessThenMaximum()
        {
            Node<int> node = new(1);
            node.Append(5);
            node.Append(4);
            node.Append(3);
            node.Append(2);

            int count = 0;
            foreach (var item in node.ChildItems(0))
            {
                count++;
            }

            Assert.AreEqual(0, count);


            count = 0;
            foreach (var item in node.ChildItems(1))
            {
                count++;
            }
            Assert.AreEqual(0, count);


            count = 0;
            foreach (var item in node.ChildItems(2))
            {
                count++;
            }
            Assert.AreEqual(1, count);


            count = 0;
            foreach (var item in node.ChildItems(3))
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void SimpleTest_ForEachChildItems_ReturnsEachOnlyOnce()
        {
            Node<int> node = new(1);
            node.Append(5);
            node.Append(4);
            node.Append(3);
            node.Append(2);

            int count = 0;
            foreach (var item in node.ChildItems(10))
            {
                count++;
            }
            Assert.AreNotEqual(10, count);

            Assert.AreEqual(5, count);
        }
    }
}