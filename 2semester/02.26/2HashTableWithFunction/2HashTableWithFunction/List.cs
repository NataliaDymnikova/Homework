using System;
using ElementType = System.Int32;
using Position = System.Int32;

namespace NList
{
    /// <summary>
    /// It is magic class! it has a lot of supernatural abilities. 
    /// </summary>
    public class List
    {
        public List()
        {
            head = null;
        }

        /// <summary>
        /// Add element to end with value value.
        /// </summary>
        /// <param name="value"></param>
        public void AddElement(ElementType value)
        {
            if (head == null)
            {
                head = new ListElement(value, null);
                return;
            }
            ListElement temp = head;
            for (temp = head; temp.Next() != null; temp = temp.Next()) ;
            temp.AddListElement(value);
        }

        /// <summary>
        /// Add element after position pos.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pos"></param>
        public void AddElementToPosition(ElementType value, Position pos)
        {
            if (head == null)
            {
                head = new ListElement(value, null);
                return;
            }
            if (pos == 0)
            {
                AddElementToHead(value);
                return;
            }
            ListElement temp = head;
            int i = 0;
            for (i = 0; temp.Next() != null && i != pos - 1; temp = temp.Next(), i++) ;
            temp.AddListElement(value);
        }

        /// <summary>
        /// Add element to head with value value. 
        /// </summary>
        /// <param name="value"></param>
        public void AddElementToHead(ElementType value)
        {
            head = new ListElement(value, head);
        }

        /// <summary>
        /// Delete element with value deleteNum. 
        /// </summary>
        /// <param name="deleteNum"></param>
        public void DeleteElement(ElementType deleteNum)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            ListElement temp = head;
            if (head.Value() == deleteNum)
                head = head.Next();
            else
            {
                while (temp.Next() != null && temp.Next().Value() != deleteNum)
                    temp = temp.Next();
                if (temp.Next() != null)
                    temp.DeleteListElement();
            }
        }

        /// <summary>
        /// Search position element.
        /// </summary>
        /// <param name="value"></param>
        /// <returns> Position element with vale value. </returns>
        public Position PositionElement(ElementType value)
        {
            ListElement temp = head;
            int i = 0;
            for (temp = head; temp != null && temp.Value() != value; temp = temp.Next(), i++) ;
            if (temp != null)
                return i;
            return -1;
        }

        /// <summary>
        /// Return true or false - exist element value in stack. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns> Exist element or not. </returns>
        public bool Exist(ElementType value)
        {
            if (head == null)
                return false;
            ListElement temp = head;
            for (temp = head; temp.Next() != null && temp.Value() != value; temp = temp.Next()) ;
            return (temp.Value() == value);
        }

        /// <summary>
        /// Is this list empty.
        /// </summary>
        /// <returns> True - if list empty, false - otherwise. </returns>
        public bool IsEmpty()
        {
            if (head == null || this == null)
                return true;
            return false;
        }

        /// <summary>
        /// Print list.
        /// </summary>
        public void Print()
        {
            Console.WriteLine();
            if (head == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }
            ListElement temp = head;
            for (temp = head; temp.Next() != null; temp = temp.Next())
                Console.Write("{0}, ", temp.Value());
            Console.WriteLine("{0}", temp.Value());
        }

        public ElementType ValueHead()
        {
            return head.Value();
        }

        private ListElement head;

        /// <summary>
        /// Class have value and pointer to the next element. 
        /// </summary>
        private class ListElement
        {
            public ListElement()
            { }
            
            public ListElement(ElementType value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }
            
            /// <summary>
            /// Add element before this with value value. 
            /// </summary>
            /// <param name="value"></param>
            public void AddListElement(ElementType value)
            {
                ListElement temp = new ListElement(value, this.next);
                this.next = temp;
            }

            /// <summary>
            /// Delete after this.
            /// </summary>
            public void DeleteListElement()
            {
                this.next = this.next.next;
            }

            /// <summary>
            /// Return value of element.
            /// </summary>
            /// <returns> Value of element. </returns>
            public ElementType Value()
            {
                return this.value;
            }

            /// <summary>
            /// Return next element.
            /// </summary>
            /// <returns>Nexr element. </returns>
            public ListElement Next()
            {
                return this.next;
            }

            private ElementType value;
            private ListElement next;
        }
    }
}
