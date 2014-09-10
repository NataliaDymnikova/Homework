/* Test is Ok -
 *              1 2 + = 3
 *              1 2 3 - + = 0
 *              9 6 - 1 2 + * = 9
 *              
 *              If you want stack in List ot in Massive comment in Calculator.cs what you want.
 */
using System;
using NCalculator;
using NStack;

namespace _4calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = null;
            Console.WriteLine("1 - for Stack in List");
            Console.WriteLine("2 - for Stack in Massive");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
                calculator = new Calculator(new NStackInList.StackInList());
            else
                calculator = new Calculator(new NStackInMassive.StackInMassive());
            int whatDo = -1;
            while (whatDo != 0)
            {
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - put number to stack");
                Console.WriteLine("2 - put +, -, * or / to stack");
                Console.WriteLine("3 - output result");
                whatDo = Convert.ToInt32(Console.ReadLine());
                
                if (whatDo == 1)
                {
                    Console.WriteLine("Enter new number");
                    int newNum = Convert.ToInt32(Console.ReadLine());
                    calculator.AddNumber(newNum);
                }
                if (whatDo == 2)
                {
                    Console.WriteLine("Enter new sign");
                    char newSign = Convert.ToChar(Console.ReadLine());
                    calculator.AddSign(newSign);
                }
                if (whatDo == 3)
                {
                    Console.WriteLine("result = {0}", calculator.OutputResult());
                }
            }
        }
    }
}
