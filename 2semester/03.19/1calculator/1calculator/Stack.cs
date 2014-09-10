using System;

namespace _1calculator
{
    /// <summary>
    /// Stack class.
    /// </summary>
    public class Stack
    {
        public Stack()
        {
            head = null;
        }

        // add element newValue to head.
        public void Push(int newValue)
        {
            ListElement temp = new ListElement(newValue, head);
            head = temp;
        }

        // delete element in head and return value.
        public int Pop()
        {
            if (head == null)
                throw new StackException("Stack is empty. Can't pop");
            int val = head.Value();
            head = head.Next();
            return val; 
        }

        public bool IsEmpty()
        {
            return (head == null);
        }

        // print stack.
        public string Print()
        {
            string str = null;
            if (head == null)
                return str;
            str = head.Value().ToString();
            if (head.Next() != null)
                if (head.Next().Next() != null)
                    str = head.Next().Next().Value().ToString() + (char)head.Next().Value() + head.Value().ToString();
                else
                    str = head.Next().Value().ToString() + (char)head.Value();
            else
                str = head.Value().ToString();
            return str;
        }

        public void Clean()
        {
            head = null;
        }

        private ListElement head;

        private class ListElement
        {
            public ListElement()
            { }

            public ListElement(int value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }

            public int Value()
            {
                return this.value;
            }

            public ListElement Next()
            {
                return this.next;
            }

            private int value;
            private ListElement next;
        }
    
    }
}
