using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tree;
using Tree = Tree.Tree;

namespace UnitTestDataStructure
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        private BinarySearchTree<int> _tree = new BinarySearchTree<int>();

        [TestMethod]
        public void Insert_Test()
        {
            for (int i = 0; i < 10; i++)
            {
                _tree.Insert(i);
            }
            Assert.AreEqual(_tree.Root.Element, 5);
        }
    }
}
