using System;
using NStack;
using ElementType = System.Int32;

namespace NStackInMassive
{
    // Realizes a stack on the massive.
    public class StackInMassive: NStack.Stack
    {
        public StackInMassive()
        {
            mas = new ElementType[size];
            numberElement = 0;
        }

        // add element newValue to tail.
        public void Push(ElementType newValue)
        {
            if (numberElement == size)
                return;
            mas[numberElement] = newValue;
            numberElement++;
        }

        // delete element in head and return value.
        public ElementType Pop()
        {
            if (numberElement == 0)
                return -1;
            return mas[--numberElement]; 
        }

        // print stack.
        public void Print()
        {
            if (numberElement == 0)
            {
                Console.WriteLine("Stack is empty");
                return;
            }
            for (int i = 0; i < numberElement - 1; i++)
                Console.Write("{0} -> ", mas[i]);
            Console.Write("{0}", mas[numberElement - 1]); 
            Console.WriteLine();
        }

        // return value of head.
        public ElementType ValueHead()
        {
            return mas[numberElement - 1];
        }

        private ElementType[] mas;
        // size array.
        private int size = 100;
        //number element in massive.
        private int numberElement;
    }
}
