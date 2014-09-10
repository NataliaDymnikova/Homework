using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoldTest
{
    using _3Fold;
    using System.Collections.Generic;

    [TestClass]
    public class FoldTest
    {
        [TestMethod]
        public void FoldTest1()
        {
            Assert.AreEqual(FoldClass.Fold(new List<int>(3) { 1, 2, 3 }
                , 1, (accam, elem) => accam * elem), 6);
        }
    }
}
