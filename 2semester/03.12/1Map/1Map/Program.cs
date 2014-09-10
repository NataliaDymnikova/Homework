using System;
using System.Collections.Generic;

namespace _1Map
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = MapClass.Map(new List<int>(3) { 1, 2, 3 }, x => x * x);
            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
