using System;
using NStack;

namespace NCalculator
{
    // Realize calculate: can add number, +, -, *, \, output result
    public class Calculator
    {
        public Calculator(Stack newStack)
        {
            stack = newStack;
        }
        
        // add number to stack.
        public void AddNumber(int newNumber)
        {
            stack.Push(newNumber);
        }

        // calculate 2 numbers with sign.
        public void AddSign(char sign)
        {
            CalculateTwoNumbers(sign);
        }

        // return value in head in stack.
        public int OutputResult()
        {
            stack.Print();
            return stack.ValueHead();
        }

        //calculate 2 numbers in stack with sign, push result.
        private void CalculateTwoNumbers(char sign)
        {
	        int value1 = stack.Pop();
	        int value2 = stack.Pop();
	        int valueResult = 0;
	        if (sign == '+')
		        valueResult = value1 + value2; 
	        else if (sign == '-')
		        valueResult = value2 - value1; 
	        else if (sign == '*')
		        valueResult = value1 * value2; 
	        else if (sign == '/')
		        valueResult = value2 / value1; 
	        stack.Push(valueResult);
        }

        private Stack stack;
    }
}
