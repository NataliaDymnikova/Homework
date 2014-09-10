using System;
using System.Collections.Generic;

namespace _2Filter
{
    public class FilterClass
    {
        /// <summary>
        /// Filter element of the list.
        /// </summary>
        /// <param name="list"> List which is filtered. </param>
        /// <param name="func"> Filter function. </param>
        /// <returns> New filtered list. </returns>
        static public List<int> Filter(List<int> list, Func<int, bool> func) 
        {
            List<int> newList = new List<int>();
            foreach (var temp in list)
                if (func(temp))
                    newList.Add(temp);
            
            return newList;
        }
    }
}
