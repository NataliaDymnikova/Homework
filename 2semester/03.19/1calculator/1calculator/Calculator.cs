using System;

namespace _1calculator
{
    /// <summary>
    /// Class to keep and calculate two numbers.
    /// </summary>
    public class Calculator
    {
        public Calculator()
        {
            stack = new Stack();
        }

        /// <summary>
        /// </summary>
        /// <returns> String calculator. </returns>
        public string Print()
        {
            return this.stack.Print();
        }

        /// <summary>
        /// Add new number.
        /// </summary>
        /// <param name="newValue"> Number to add. </param>
        public void Add(int newValue)
        {
            if (this.stack.IsEmpty())
                this.stack.Push(newValue);
            else
            {
                this.stack.Push(newValue);
                Calculate();
            }
        }

        /// <summary>
        /// Add new sign.
        /// </summary>
        /// <param name="newValue"> Sign to add. </param>
        public void Add(char newValue)
        {
            if (this.stack.IsEmpty())
                return;
            int previous = this.stack.Pop();
            if (this.stack.IsEmpty())
            {
                this.stack.Push(previous);
                this.stack.Push(newValue);
            }
            else
            {
                int preprevious = this.stack.Pop();
                if (this.stack.IsEmpty())
                {
                    this.stack.Push(preprevious);
                    this.stack.Push(newValue);
                }
                else
                {
                    this.stack.Push(preprevious);
                    this.stack.Push(previous);
                    Calculate();
                    this.stack.Push(newValue);
                }
            }
        }
 
        public void Clean()
        {
            stack.Clean();
        }
       
        private void Calculate()
        {
            int rightValue = 0;
            int leftValue = 0;
            char sign = '0';
            if (!stack.IsEmpty())
                rightValue = stack.Pop();
            else
                return;
            if (!stack.IsEmpty())
                sign = (char) stack.Pop();
            else
            {
                stack.Push(rightValue);
                return;
            }
            if (!stack.IsEmpty())
                leftValue = stack.Pop();
            else
            {
                stack.Push(rightValue);
                return;
            }
            stack.Push(CalculateTwoNumbers(leftValue, rightValue, sign));
        }

        // Calculate left 'sign' right.
        private int CalculateTwoNumbers(int left, int right, char sign)
        {
            if (sign == '+')
                return left + right;
            if (sign == '-')
                return left - right;
            if (sign == '*')
                return left * right;
            if (sign == '/' && right != 0)
                return left / right;
            
            return 0;
        }

        private Stack stack;
    }
}
