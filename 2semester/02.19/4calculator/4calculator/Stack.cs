using System;
using ElementType = System.Int32;

namespace NStack
{
    // I don't now how to write a comment=) because it's just a stack.
    public interface Stack
    {
       // add element newValue to head.
        void Push(ElementType newValue);
        
        // delete element in head and return value.
        ElementType Pop();

        // print stack.
        void Print();

        // return value of head.
        ElementType ValueHead();
    }
}
