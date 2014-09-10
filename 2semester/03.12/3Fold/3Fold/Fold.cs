using System;
using System.Collections.Generic;

namespace _3Fold
{
    public class FoldClass
    {
        /// <summary>
        /// Function application consistently to all elements.
        /// </summary>
        /// <param name="list"> List which elements we use. </param>
        /// <param name="firstValue"> First value which we use. </param>
        /// <param name="func"> Function we use. </param>
        /// <returns> Result. </returns>
        static public int Fold(List<int> list, int firstValue, Func<int, int, int> func) 
        {
            int returnValue = firstValue;
            foreach (var temp in list)
                returnValue = func(returnValue, temp);
            return returnValue;
        }
    }
}
