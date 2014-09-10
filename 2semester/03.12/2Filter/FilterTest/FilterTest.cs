using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FilterTest
{
    using _2Filter;

    [TestClass]
    public class FilterTest
    {
        [TestMethod]
        public void FilterTest1()
        {
            List<int> list = FilterClass.Filter(
                new List<int>() { 1 }, x => (x % 2 == 0));
            Assert.IsTrue(list.Count == 0);
        }
    }
}
