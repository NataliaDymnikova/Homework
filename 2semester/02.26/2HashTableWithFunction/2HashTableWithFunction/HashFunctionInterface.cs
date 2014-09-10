using System;
using ElementType = System.Int32;

namespace _2HashTableWithFunction
{
    /// <summary>
    /// Interface for hash function. 
    /// </summary>
    public interface HashFunctionInterface
    {
        int Function(ElementType newElement);
    }
}
