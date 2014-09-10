using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SetTest
{
    using _2ADTset;

    [TestClass]
    public class SetTestClass
    {
        [TestInitialize]
        public void Initialize()
        {
            set = new ADTset<int>();
        }

        [TestMethod]
        public void AddTest()
        {
            set.Add(5);
            Assert.IsTrue(set.Exist(5));
        }

        [TestMethod]
        public void DeleteTest()
        {
            set.Add(5);
            set.Add(2);
            set.Delete(5);
            Assert.IsFalse(set.Exist(5));
        }

        [TestMethod]
        public void AddSomeEquelsValue()
        {
            set.Add(1);
            set.Add(2);
            set.Add(1);
            set.Delete(1);
            Assert.IsFalse(set.Exist(1));
        }

        [TestMethod]
        public void UnionTest()
        {
            var secondSet = new ADTset<int>();
            secondSet.Add(2);
            set.Add(1);
            set.Union(secondSet);
            Assert.IsTrue(set.Union(secondSet).Exist(2));
        }

        [TestMethod]
        public void IntersectionTest()
        {
            var secondSet = new ADTset<int>();
            secondSet.Add(2);
            secondSet.Add(1);
            set.Add(2);
            set.Union(secondSet);
            Assert.IsTrue(set.Intersection(secondSet).Exist(2));
        }

        private ADTset<int> set;
    }
}
