using System;
using NStack;
using ElementType = System.Int32;

namespace NStackInList
{
    // Realizes a stack on the ADT list.
    public class StackInList: NStack.Stack
    {
        public StackInList()
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

        // return value of head.
        public ElementType ValueHead()
        {
            return head.Value();
        }

        private ListElement head;

        // this class have private element: value and pointer to the next element.
        // have emty constructor, constructor with value and next element.
        // can add and delete next element, return value and next element.
        private class ListElement
        {
            public ListElement()
            { }

            public ListElement(ElementType value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }

            // return value.
            public ElementType Value()
            {
                return this.value;
            }

            // return next element.
            public ListElement Next()
            {
                return this.next;
            }

            private ElementType value;
            private ListElement next;
        }

    }
}
