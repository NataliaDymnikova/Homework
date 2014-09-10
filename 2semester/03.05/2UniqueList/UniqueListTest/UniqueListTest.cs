using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2UniqueList;

namespace NUniqueListTest
{
    [TestClass]
    public class UniqueListTest
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList();
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUniqueListToAdd))]
        public void AddExistElementTest()
        {
            list.AddElement(2);
            list.AddElement(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUniqueListToDelete))]
        public void DeleteNotExistElementTest()
        {
            list.DeleteElement(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUniqueListToAdd))]
        public void AddElementToPositionTest()
        {
            list.AddElementToPosition(2, 0);
            list.AddElementToPosition(2, 1);
        }

        private UniqueList list;
    }
}
