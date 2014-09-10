using System;
using System.Collections;
using Position = System.Int32;

namespace NList
{
    /// <summary>
    ///  Realizes the ADT List.
    /// </summary>
    /// <typeparam name="ElementType"> Type of element. </typeparam>
    public class List<ElementType> : IEnumerator, IEnumerable
    {
        public List()
        {
            head = null;
        }

        /// <summary>
        /// Add element to end.
        /// </summary>
        /// <param name="value"> New element. </param>
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
        /// Add element after position.
        /// </summary>
        /// <param name="value"> New element. </param>
        /// <param name="pos"> Position. </param>
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
        /// Add element to head with value.
        /// </summary>
        /// <param name="value">New element. </param>
        public void AddElementToHead(ElementType value)
        {
            head = new ListElement(value, head);
        }

        /// <summary>
        /// Delete element with value deleteNum.
        /// </summary>
        /// <param name="deleteNum"> Delete element. </param>
        public void DeleteElement(ElementType deleteNum)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            ListElement temp = head;
            if (Equals(head.Value(), deleteNum))
                head = head.Next();
            else
            {
                while (temp.Next() != null && !Equals(temp.Next().Value(), deleteNum))
                    temp = temp.Next();
                if (temp.Next() != null)
                    temp.DeleteListElement();
            }
        }

        /// <summary>
        /// Return position element with vale value.
        /// </summary>
        /// <param name="value"> Value element. </param>
        /// <returns> Number position this element. </returns>
        public Position PositionElement(ElementType value)
        {
            ListElement temp = head;
            int i = 0;
            for (temp = head; temp != null && !Equals(temp.Value(), value); temp = temp.Next(), i++) ;
            if (Equals(temp.Value(), value))
                return i;
            return -1;
        }

        /// <summary>
        /// Return true or false - exist element value in stack.
        /// </summary>
        /// <param name="value"> Elemet. </param>
        /// <returns> True - if element exist. Else - false. </returns>
        public bool Exist(ElementType value)
        {
            if (head == null)
                return false;
            ListElement temp = head;
            for (temp = head;  temp.Next() != null && !Equals(temp.Value(), value); temp = temp.Next());
            return (Equals(temp.Value(), value));
        }

        /// <summary>
        /// Print stack.
        /// </summary>
        public string Print()
        {
            string listString = null;
            foreach (ListElement temp in this)
            {
                listString += temp.Value().ToString();
            }
            return listString;
        }

        // All for IEnumerator.
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            toENumerator++;
            return !(ElementInPosition(toENumerator) == null);
        }

        public void Reset()
        {
            toENumerator = -1; 
        }

        public object Current
        {
            get { return ElementInPosition(toENumerator); }
        }

        /// <summary>
        /// Return element in position.
        /// </summary>
        /// <param name="position"> Number position. </param>
        /// <returns> ListElement position. </returns>
        private ListElement ElementInPosition(int position)
        {
            var temp = head;
            for (int i = 0; i < position && temp != null; i++)
                temp = temp.Next();
            return temp;
        }


        private ListElement head;
        private int toENumerator = -1;

        /// <summary>
        /// Class of element list in pointer.
        /// </summary>
        private class ListElement
        {
            public ListElement()
            { }
            
            // do this element with value and next.
            public ListElement(ElementType value, ListElement next)
            {
                this.value = value;
                this.next = next;
            }

            // add element before this with value value.
            public void AddListElement(ElementType value)
            {
                ListElement temp = new ListElement(value, this.next);
                this.next = temp;
            }

            // delete after this.
            public void DeleteListElement()
            {
                this.next = this.next.next;
            }

            // return value of element.
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
