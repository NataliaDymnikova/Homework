using System;
using System.Collections.Generic;

namespace _3Fold
{
    public class Program
    {
        static void Main(string[] args)
        {
            int result = FoldClass.Fold(new List<int>(3) { 1, 2, 3 }
                , 1, (accam, elem) => accam * elem);
            Console.WriteLine(result);

        }
    }
}
