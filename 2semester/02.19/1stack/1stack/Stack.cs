using System;

using ElementType = System.Int32;

namespace NStack
{
    public class Stack
    {
        public Stack()
        {
            head = null;
        }

        // add element newValue to head.
        public void Push(ElementType newValue)
        {
            ListElement temp = new ListElement(newValue, head);
            head = temp;
        }

        // delete element in head and return value.
        public ElementType Pop()
        {
            if (head == null)
                return -1;
            ElementType val = head.Value();
            head = head.Next();
            return val; 
        }

        // print stack.
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
