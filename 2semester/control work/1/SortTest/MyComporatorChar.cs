using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    /// <summary>
    /// Class of compare char.
    /// </summary>
    class MyComporatorChar : IComparer<char>
    {
        int IComparer<char>.Compare(char first, char second)
        {
            if (first > second)
                return 1;
            if (first < second)
                return -1;
            return 0;
        }
    }
}
