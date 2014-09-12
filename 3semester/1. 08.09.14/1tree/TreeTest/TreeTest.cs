using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1tree;

namespace TreeTest
{
    /// <summary>
    /// Class for testing tree.
    /// </summary>
    [TestClass]
    public class TreeTestClass
    {
        [TestInitialize]
        public void Initialize()
        {
            tree = new Tree<int>();
            tree.Add(5);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
            tree.Add(4);
        }

        [TestMethod]
        public void AddTest()
        {
            for (int i = 1; i <= 5; i++)
                Assert.IsTrue(tree.IsExist(i));
        }

        [TestMethod]
        public void DeleteTest()
        {
            tree.Delete(2);
            Assert.IsFalse(tree.IsExist(2));
            Assert.IsTrue(tree.IsExist(1));
            Assert.IsTrue(tree.IsExist(3));
            Assert.IsTrue(tree.IsExist(4));
            Assert.IsTrue(tree.IsExist(5));
        }

        [TestMethod]
        public void DeleteRootTest()
        {
            tree.Delete(5);
            Assert.IsFalse(tree.IsExist(5));
            for (int i = 1; i < 5; i++ )
                Assert.IsTrue(tree.IsExist(i));
        }

        [TestMethod]
        public void ForeachTest()
        {
            int j = 1;
            foreach (int i in tree)
                Assert.IsTrue(i == j++);
        }

        [TestMethod]
        public void DeleteAllTest()
        {
            for (int i = 1; i < 6; i++)
            {
                tree.Delete(i);
                Assert.IsFalse(tree.IsExist(i));
            }
        }

        private Tree<int> tree;
    }
}
