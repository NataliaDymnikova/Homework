using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1BTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree<int> tree = new BTree<int>(1);
            tree.Add(5, 5);
            tree.Add(1, 1);
            tree.Add(2, 2);
            tree.Add(4, 4);
            tree.Add(6, 6);

            Console.WriteLine(tree.ToPrint());
        }
    }
}
