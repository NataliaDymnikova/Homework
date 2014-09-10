using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SortTest
{
    using Sorting;

    /// <summary>
    /// Class of testing sort.
    /// </summary>
    [TestClass]
    public class SortTestClass
    {
        [TestMethod]
        public void SortIntTest()
        {
            int[] mas = new int[5] {2, 1, 4, 3, 0};
            IComparer<int> comparer = new MyComporatorInt();
            mas = BubbleSort<int>.Sort(mas, 5, comparer);
            Assert.IsTrue(mas[0] == 0);
            Assert.IsTrue(mas[1] == 1);
            Assert.IsTrue(mas[2] == 2);
            Assert.IsTrue(mas[3] == 3);
            Assert.IsTrue(mas[4] == 4);
        }

        [TestMethod]
        public void SortCharTest()
        {
            char[] mas = new char[3];
            mas[0] = 'b';
            mas[1] = 'c';
            mas[2] = 'a';
            IComparer<char> comparer = new MyComporatorChar();
            mas = BubbleSort<char>.Sort(mas, 3, comparer);
            Assert.IsTrue(mas[0] == 'a');
            Assert.IsTrue(mas[1] == 'b');
            Assert.IsTrue(mas[2] == 'c');
        }


    }
}
