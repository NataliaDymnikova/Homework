using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MapTest
{
    using _1Map;

    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void MapTest1()
        {
            List<int> list = MapClass.Map(new List<int>(3) { 1 }, x => x + x);
            Assert.IsTrue(list.Exists(x => x==2));
        }
    }
}
