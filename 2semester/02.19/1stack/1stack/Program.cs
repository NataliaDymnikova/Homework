/* Test is Ok - 
 *              1 - 3, 1 - 2, 1 - 1 : 1->2->3
 *              2: 2->3
 *              2: 3
 *              2: Stack is empty
 *              1 - 1: 1
 */
using System;

using NStack;

namespace _1stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
           	int whatDo = -1;
	        while (whatDo != 0)
	        {
		        Console.WriteLine("0 - exit"); 
			    Console.WriteLine("1 - push"); 
			    Console.WriteLine("2 - pop"); 
			    whatDo = Convert.ToInt32(Console.ReadLine());
		        if (whatDo == 1)
		        {
			        int newNum = 0;
			        Console.WriteLine("Enter number for add - ");
			        newNum = Convert.ToInt32(Console.ReadLine());
			        stack.Push(newNum);
		        }
		        if (whatDo == 2)
		        {
                    int value = stack.Pop();
                    if (value == -1)
                        Console.WriteLine("Stack is empty");
                    else
                        Console.WriteLine("delete element - {0}", value);
			    }
		        stack.Print();
		    }
        }
    }
}
