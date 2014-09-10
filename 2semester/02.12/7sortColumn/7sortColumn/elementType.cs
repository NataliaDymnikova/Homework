using System;

namespace NElementType
{
    // тип, элемент которого массив, определяемый по первому значению.
    class ElementType
    {
        public ElementType(int size, Random rand)
        {
            mas = new int[size];
            for (int j = 0; j < size; j++)
                mas[j] = rand.Next(100);
        }

        public static void Swap(ref ElementType swapOne, ref ElementType swapTwo)
        {
            int[] swapSwap = swapOne.mas;
            swapOne.mas = swapTwo.mas;
            swapTwo.mas = swapSwap;
        }

        public int Value()
        {
            return mas[0];
        }

        public void Print(int numOfLine)
        {
            Console.Write("{0}, ", mas[numOfLine]);
        }
        
        private int[] mas;
    }
}
