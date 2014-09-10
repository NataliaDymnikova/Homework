/* Test is Ok - 
 *              1 - 1, 2
 *              2 - 0: 0, 1, 2
 *              3 - 2: 0, 1
 *              4 - 1: exist, 2: not exist.
 *              3 - 0: 1,
 *              3 - 1: empty
 */
using System;
using NList;

namespace _2list
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            int whatDo = -1;
            while (whatDo != 0)
            {
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - add element to tail");
                Console.WriteLine("2 - add element to head");
                Console.WriteLine("3 - add element to position");
                Console.WriteLine("4 - delete element");
                Console.WriteLine("5 - exist element");
                whatDo = Convert.ToInt32(Console.ReadLine());
                if (whatDo == 1)
                {
                    Console.WriteLine("Enter number for add - ");
                    int newNum = Convert.ToInt32(Console.ReadLine());
                    list.AddElement(newNum);
                }
                if (whatDo == 2)
                {
                    Console.WriteLine("Enter number for add - ");
                    int newNum = Convert.ToInt32(Console.ReadLine());
                    list.AddElementToHead(newNum);
                }
                if (whatDo == 3)
                {
                    Console.WriteLine("Enter number for add - ");
                    int newNum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter number position to add - ");
                    int numPos = Convert.ToInt32(Console.ReadLine());
                    list.AddElementToPosition(newNum, numPos);
                }
                if (whatDo == 4)
                {
                    Console.WriteLine("Enter number for delete - ");
                    int deleteNum = Convert.ToInt32(Console.ReadLine());
                    list.DeleteElement(deleteNum);
                }
                if (whatDo == 5)
                {
                    Console.WriteLine("Enter number for exist - ");
                    int existNum = Convert.ToInt32(Console.ReadLine());
                    if (list.Exist(existNum))
                        Console.WriteLine("{0} exist", existNum);
                    else
                        Console.WriteLine("{0} not exist", existNum);
                }
                
                list.Print();
            }
        }
    }
}
