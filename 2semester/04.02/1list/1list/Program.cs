using System;

namespace _1list
{
    class Program
    {
        static void Main(string[] args)
        {
            NList.List<int> list = new NList.List<int>();
            list.AddElement(1);
            list.AddElement(2);
            list.AddElement(3);
            Console.WriteLine(list.Print());
        }
    }
}
