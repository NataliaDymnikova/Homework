using System;
using System.Collections.Generic;

namespace NStack
{
    /// <summary>
    /// Generic stack.
    /// </summary>
    /// <typeparam name="ElementType"> Type of element. </typeparam>
    public class Stack<ElementType>
    {
        public Stack()
        {
            head = null;
        }

        /// <summary>
        /// Add element to head.
        /// </summary>
        /// <param name="newValue"> Value new element. </param>
        public void Push(ElementType newValue)
        {
            ListElement temp = new ListElement(newValue, head);
            head = temp;
        }

        /// <summary>
        /// Delete element in head and return value.
        /// </summary>
        /// <returns> Element which delete. </returns>
        public ElementType Pop()
        {
            if (head == null)
                throw new Exception();
            ElementType val = head.Value();
            head = head.Next();
            return val; 
        }

        /// <summary>
        /// Print stack.
        /// </summary>
        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("Stack is empty");
                return;
            }
            ListElement pos = head;
            for (pos = head; pos.Next() != null; pos = pos.Next())
                Console.Write("{0} -> ", pos.Value());
            Console.Write("{0}", pos.Value()); 
            Console.WriteLine();
        }

       private ListElement head;

       // Class of element stack.
       private class ListElement
       {
           public ListElement()
           { }

           public ListElement(ElementType value, ListElement next)
           {
               this.value = value;
               this.next = next;
           }

           public ElementType Value()
           {
               return this.value;
           }

           public ListElement Next()
           {
               return this.next;
           }

           private ElementType value;
           private ListElement next;
       }

    }
}
