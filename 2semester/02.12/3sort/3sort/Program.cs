/* Test is Ok -
 *              2: 87, 22
 *              5: 13, 73, 67, 60, 33
 */
using System;

using NSort;
using NElemntType;

namespace _3sort
{
    class Program
    {
        static void printMas(ElementType[] mas, int size)
        {
            for (int i = 0; i < size; i++)
                mas[i].Print();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter size of array:");
            string input = Console.ReadLine();
            int sizeArray  = Convert.ToInt32(input); 
            ElementType[] mas = new ElementType[sizeArray];
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < sizeArray; i++)
                mas[i] = new ElementType(rand.Next(0,100));

            Console.WriteLine("Not sort mas:");
            printMas(mas, sizeArray);
            QSort.Qsort(mas, 0, sizeArray - 1);
            Console.WriteLine("Sort mas:");
            printMas(mas, sizeArray);
            
        }
    }
}
