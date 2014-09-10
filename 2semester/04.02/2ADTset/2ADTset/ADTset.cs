using System;
using System.Collections.Generic;

namespace _2ADTset
{
    public class ADTset<ElementType> where ElementType : IComparable<ElementType>
    {
        public ADTset()
        {
            head = null;
        }
        
        /// <summary>
        /// Add new element to high.
        /// </summary>
        /// <param name="newValue"> Value of new element. </param>
        public void Add(ElementType newValue)
        {
            if (head == null)
            {
                head = new ListElement(newValue, null);
                return;
            }
            if (head.Value().CompareTo(newValue) == 0)
                return;
            if (head.Value().CompareTo(newValue) > 0)
            {
                head = new ListElement(newValue, head);
                return;
            }
            var temp = head;
            while (temp.Next() != null && temp.Next().Value().CompareTo(newValue) < 0)
                temp = temp.Next();
            if (temp.Next() != null)
                if (temp.Next().Value().CompareTo(newValue) == 0)
                    return;
            temp.AddListElement(newValue);
        }

        /// <summary>
        /// Delete element.
        /// </summary>
        /// <param name="deleteValue"> Value of delete element. </param>
        public void Delete(ElementType deleteValue)
        {
            if (head == null)
                return;
            if (head.Value().CompareTo(deleteValue) == 0)
            {
                head = head.Next();
                return;
            }
            var temp = head;
            while (temp.Next() != null && temp.Next().Value().CompareTo(deleteValue) < 0)
                temp = temp.Next();

            if (temp.Next() == null)
                return;

            if (temp.Next().Value().CompareTo(deleteValue) == 0)
                temp.DeleteNextListElement();
        }

        /// <summary>
        /// Exist element or not.
        /// </summary>
        /// <param name="value"> Value of exist element. </param>
        /// <returns> True - if element exist in set, else - false. </returns>
        public bool Exist(ElementType value)
        {
            if (head == null)
                return false;
            var temp = head;
            while (temp != null && temp.Value().CompareTo(value) < 0)
                temp = temp.Next();

            if (temp == null)
                return false;
            if (temp.Value().CompareTo(value) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Make union of this set and secondSet.
        /// </summary>
        /// <param name="secondSet"> Second set to union. </param>
        /// <returns> New set - union of the sets. </returns>
        public ADTset<ElementType> Union(ADTset<ElementType> secondSet)
        {
            var unionSet = new ADTset<ElementType>();
            for (var tempThis = head; tempThis != null; tempThis = tempThis.Next())
                unionSet.Add(tempThis.Value());
            for (var tempSecondSet = secondSet.head; tempSecondSet != null; tempSecondSet = tempSecondSet.Next())
                unionSet.Add(tempSecondSet.Value());
            
            return unionSet;
        }

        /// <summary>
        /// Make intersection os this set and secondSet.
        /// </summary>
        /// <param name="secondSet"> Second set to intersection. </param>
        /// <returns> New set - intersection of sets. </returns>
        public ADTset<ElementType> Intersection(ADTset<ElementType> secondSet)
        {
            var intersectionSet = new ADTset<ElementType>();
            var tempThis = head;
            var tempSecondSet = secondSet.head;
            while (tempSecondSet != null && tempThis != null)
            {
                if (tempThis.Value().CompareTo(tempSecondSet.Value()) == 0)
                {
                    intersectionSet.Add(tempThis.Value());
                    tempThis = tempThis.Next();
                    tempSecondSet = tempSecondSet.Next();
                }
                else if (tempThis.Value().CompareTo(tempSecondSet.Value()) < 0)
                    tempThis = tempThis.Next();
                else
                    tempSecondSet = tempSecondSet.Next();
            }
            return intersectionSet;
        }

        private ListElement head;

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
            public void DeleteNextListElement()
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
