using System;

namespace _2HashTableWithFunction
{
    public class HashFunctionClass1: HashFunctionInterface
    {
        public int Function(int num)
        {
            return num * num + num * 3 + 2;
        }
    }
}
