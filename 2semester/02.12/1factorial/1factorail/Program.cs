/* Test is Ok - 
 *              3! = 6
 *              5! = 120
 */
using System;

namespace _1factorial
{
    class Program
    {
        // Подсчет факториала числа num.
        static int Factorial(int num)
        {
            if (num == 1)
                return 1;
            return num * Factorial(num - 1);
        }

        static void Main(string[] args)
        {
            int num = 0;
            Console.WriteLine("Enter number for factorial:");
            string input = Console.ReadLine();
            num = Convert.ToInt32(input);
            Console.WriteLine("{0}! = {1}", num, Factorial(num));
        }
    }
}
