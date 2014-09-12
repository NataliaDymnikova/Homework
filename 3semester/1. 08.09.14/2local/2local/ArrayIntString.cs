using System;

namespace _2local
{
    /// <summary>
    /// Class has pairs int-string.
    /// You can get int sending string.
    /// </summary>
    class ArrayIntString
    {
        public ArrayIntString(int numberOfElements)
        {
            this.numberOfElementsAll = numberOfElements;
            number = new int[numberOfElementsAll];
            name = new string[numberOfElementsAll];
            numberOfElementsNow = 0;
        }

        /// <summary>
        /// Addd new pair int-string.
        /// </summary>
        /// <param name="newNumber"> New number. </param>
        /// <param name="newName"> New string. </param>
        public void Add(int newNumber, string newName)
        {
            if (numberOfElementsAll <= numberOfElementsNow)
                return;
            number[numberOfElementsNow] = newNumber;
            name[numberOfElementsNow] = newName;
            numberOfElementsNow++;
        }

        /// <summary>
        /// Return number with this name.
        /// </summary>
        /// <param name="searchName"> Name. </param>
        /// <returns> Number. </returns>
        public int Number(string searchName)
        {
            for (int i = 0; i < numberOfElementsNow; i++ )
            {
                if (name[i] == searchName)
                    return number[i];
            }
            return -1;
        }

        private int numberOfElementsAll;
        private int[] number;
        private string[] name;
        private int numberOfElementsNow;
    }
}
