using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackTest
{
    using NStack;

    [TestClass]
    public class StackTestClass
    {
        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack<int>();
        }

        [TestMethod]
        public void AddTest()
        {
            stack.Push(1);
            Assert.AreEqual(stack.Pop(), 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteEmptyStackTest()
        {
            stack.Pop();
        }

        [TestMethod]
        public void TestWithSomePushPop()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            stack.Push(3);
            stack.Pop();
            Assert.AreEqual(stack.Pop(), 1);
        }

        private Stack<int> stack;
    }
}
