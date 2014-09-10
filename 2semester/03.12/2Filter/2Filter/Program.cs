using System;
using System.Collections.Generic;

namespace _2Filter
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = FilterClass.Filter(
                new List<int>() { 1, 2, 3 }, x => (x % 2 != 0));
            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
