/* Test is Ok -
 *              size = 3
 *              size = 5
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6spiral
{
    class Program
    {
        // обычная печать массива.
        static void PrintMas(int[,] mas)
        {
            int size = mas.GetLength(1); 
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write("{0} ", mas[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private enum Move
        {
            Left, Down, Right, Up
        };

        // вывод массива mas по спирали с нечетным количеством элементов size.
        static void PrintMasSpiral(int[,] mas)
        {
            int size = mas.GetLength(1);
            Move speed = Move.Left;
            int i = (size - 1) / 2;
            int j = (size - 1) / 2;
            int minI = i - 1;
            int maxI = i + 1;
            int minJ = j - 1;
            int maxJ = j + 1;
            while (i != 0 || j != 0)
            {
                Console.Write("{0}, " , mas[i,j]);
                if (speed == Move.Left)
                    j--;
                else if (speed == Move.Down)
                    i++;
                else if (speed == Move.Right)
                    j++;
                else if (speed == Move.Up)
                    i--;
                if (j <= minJ && speed == Move.Left)
                {
                    speed = Move.Down;
                    minJ--;
                }
                else if (j >= maxJ && speed == Move.Right)
                {
                    speed = Move.Up;
                    maxJ++;
                }
                else if (i >= maxI && speed == Move.Down)
                { 
                    speed = Move.Right;
                    maxI++;
                }
                else if (i <= minI && speed == Move.Up)
                {
                    speed = Move.Left;
                    minI--;
                }

                if (minI < 0)
                    minI = 0;
                if (minJ < 0)
                    minJ = 0;
                if (maxI > size - 1)
                    maxI = size - 1;
                if (maxJ > size - 1)
                    maxJ = size - 1;
            }
            Console.WriteLine("{0}", mas[0, 0]);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter odd size of array:");
            string input = Console.ReadLine();
            int sizeArray = Convert.ToInt32(input);
            if (sizeArray % 2 == 0)
                sizeArray--;
            int[,] mas = new int[sizeArray, sizeArray];
            Random rand = new Random();
            for (int i = 0; i < sizeArray; i++)
                for (int j = 0; j < sizeArray; j++)
                    mas[i,j] = rand.Next(0, 100);

            PrintMas(mas);
            PrintMasSpiral(mas);
        }
    }
}
