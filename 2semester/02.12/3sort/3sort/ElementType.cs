using System;

namespace NElemntType
{
    // тип, элемент которого массив, определяемый по первому значению.
    class ElementType
    {
        private int val;

        public ElementType(int value)
        {
            val = value;
        }

        public static void Swap(ref ElementType swapOne, ref ElementType swapTwo)
        {
            int swapSwap = swapOne.val;
            swapOne.val = swapTwo.val;
            swapTwo.val = swapSwap;
        }

        public int Value()
        {
            return val;
        }

        public void Print()
        {
            Console.Write("{0}, ", val);
        }
    }
}
