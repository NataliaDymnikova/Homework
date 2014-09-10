using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace List.Test
{
    using NList;

    [TestClass]
    public class ListTest
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod]
        public void AddElementTest()
        {
            list.AddElement(2);
            Assert.IsTrue(list.Exist(2));
        }
        
        [TestMethod]
        public void PositionElementTest()
        {
            list.AddElement(1);
            Assert.IsTrue(list.PositionElement(1) == 0);
        }

        [TestMethod]
        public void AddElementToHeadTest()
        {
            list.AddElement(2);
            list.AddElementToHead(1);
            Assert.IsTrue(list.PositionElement(1) == 0);
        }

        [TestMethod]
        public void AddElementToPositionTest()
        {
            list.AddElement(2);
            list.AddElement(4);
            list.AddElementToPosition(3, 2);
            Assert.IsTrue(list.PositionElement(3) == 2);
        }

        [TestMethod]
        public void DeleteElementTest()
        {
            list.AddElement(2);
            list.DeleteElement(2);
            Assert.IsFalse(list.Exist(2));
        }

        private List list;
    }
}
