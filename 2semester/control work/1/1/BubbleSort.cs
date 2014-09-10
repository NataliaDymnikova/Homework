using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// Class Sort array.
    /// </summary>
    /// <typeparam name="ElementType"> Type of sort element. </typeparam>
    public class BubbleSort<ElementType>
    {
        /// <summary>
        /// Swap two element.
        /// </summary>
        /// <param name="first"> First to swap. </param>
        /// <param name="second"> Second to swap. </param>
        static void Swap(ref ElementType first, ref ElementType second)
        {
            ElementType temp = first;
            first = second;
            second = temp;
        }

        /// <summary>
        /// Sort array.
        /// </summary>
        /// <param name="mas"> Array to sort. </param>
        /// <param name="size"> Size array. </param>
        /// <param name="comparator"> Comporator of elements. </param>
        /// <returns> Sorting array. </returns>
        public static ElementType[] Sort(ElementType[] mas, int size, IComparer<ElementType> comparator)
        {
            for (int i = 0; i < size - 1; i++)
                for (int j = 0; j < size - 1; j++)
                {
                    if (comparator.Compare(mas[j], mas[j + 1]) > 0)
                        Swap(ref mas[j], ref mas[j + 1]);
                }
            return mas;
        }
    }
}
