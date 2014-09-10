using System;
using System.Collections.Generic;

namespace _1Map
{
    public class MapClass
    {
        /// <summary>
        /// Transforms element of the list.
        /// </summary>
        /// <param name="list"> List which transform. </param>
        /// <param name="func"> Change function element. </param>
        /// <returns> New list. </returns>
        static public List<int> Map(List<int> list, Func<int, int> func) 
        {
            List<int> newList = new List<int>();
            foreach (var temp in list)
                newList.Add(func(temp));
            
            return newList;
        }
    }
}
