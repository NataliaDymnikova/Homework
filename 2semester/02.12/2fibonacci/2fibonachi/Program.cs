/* Test is Ok -
 *              1 = 1
 *              3 = 2
 *              10 = 55
 */
using System;

namespace _2Fibonacci
{
    class Program
    {
        // Подсчет числа Фибоначчи с номером num.
        static int Fibonacci(int num)
        {
            if (num <= 2)
                return 1;
            return Fibonacci(num - 1) + Fibonacci(num - 2);
        }
        
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter number of Fibonacci:");
            string input = Console.ReadLine();
            int num = Convert.ToInt32(input);
            System.Console.WriteLine("{0} number Fibonacci = {1}", num, Fibonacci(num));
        }
    }
}
