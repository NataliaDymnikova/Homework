/* Test is Ok -
 *             1 - 1, 2, 3
 *             3 - 1: exist
 *             2 - 1
 *             3 - 1: not exist
 *             2 - 2, 3
 *             2 - 1.
 */
using System;
using NHash;

namespace _3hash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of hash table");
            Hash hash = new Hash(Convert.ToInt32(Console.ReadLine()));       
            int whatDo = -1;
            while (whatDo != 0)
            {
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - add element");
                Console.WriteLine("2 - delete element");
                Console.WriteLine("3 - exist element");
                whatDo = Convert.ToInt32(Console.ReadLine());
                if (whatDo == 1)
                {
                    int newNum = 0;
                    Console.WriteLine("Enter number for add - ");
                    newNum = Convert.ToInt32(Console.ReadLine());
                    hash.AddToHashTable(newNum);
                }
                if (whatDo == 2)
                {
                    int deleteNum = 0;
                    Console.WriteLine("Enter number for delete - ");
                    deleteNum = Convert.ToInt32(Console.ReadLine());
                    hash.DeleteElement(deleteNum);
                }
                if (whatDo == 3)
                {
                    int existNum = 0;
                    Console.WriteLine("Enter number for exist - ");
                    existNum = Convert.ToInt32(Console.ReadLine());
                    if (hash.ExistHash(existNum))
                        Console.WriteLine("{0} exist", existNum);
                    else
                        Console.WriteLine("{0} not exist", existNum);
                }
//                hash.PrintHash();
            }
        }
    }
}
