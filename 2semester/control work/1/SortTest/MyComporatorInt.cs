using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    /// <summary>
    /// Class of compare int.
    /// </summary>
    class MyComporatorInt : IComparer<int>
    {
        int IComparer<int>.Compare(int first, int second)
        {
            return first - second;
        }
    }
}
