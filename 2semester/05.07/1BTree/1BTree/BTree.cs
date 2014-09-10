using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * !!!
 * Сделать нормальное добавление, если есть свободное место.
 * Нужно погружаться вниз и там кого-то заменять.
 * !!!
 * */
namespace _1BTree
{
    /// <summary>
    /// Class BTree.
    /// </summary>
    /// <typeparam name="ValueType"> Type of value. </typeparam>
    public class BTree<ValueType>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="number"> Number elements / 2. </param>
        public BTree(int number)
        {
            root = new BTreeElement(number);
        }

        /// <summary>
        /// Add new element.
        /// </summary>
        /// <param name="newKey"> Key of element. </param>
        /// <param name="newValue"> Value of new element. </param>
        public void Add(int newKey, ValueType newValue)
        {
            root.Add(newKey, newValue);
            root = root.Root();
        }

        public string ToPrint()
        {
            return root.ToPrint();
        }

        private BTreeElement root;

        /// <summary>
        /// Class element of BTree.
        /// </summary>
        private class BTreeElement
        {
            public BTreeElement(int number = 1, BTreeElement parentNew = null)
            {
                element = new KeyValue[number * 2];
                next = new BTreeElement[2 * number + 1];
                height = 0;
                parent = parentNew;
                numberElements = number;
            }

            public BTreeElement(int newKey, ValueType newValue, BTreeElement parentNew, int number = 1)
            {
                element = new KeyValue[number * 2];
                element[0] = new KeyValue(newKey, newValue);
                next = new BTreeElement[2 * number + 1];
                height = 0;
                parent = parentNew;
                numberElements = number;
            }

            // Constructor with KeyValue.
            private BTreeElement(KeyValue newValue, BTreeElement parentNew, int number = 1)
            {
                element = new KeyValue[number * 2];
                element[0] = newValue;
                next = new BTreeElement[2 * number + 1];
                height = 0;
                parent = parentNew;
                numberElements = number;
            }

            /// <summary>
            /// Search root.
            /// </summary>
            /// <returns> Main parent. </returns>
            public BTreeElement Root()
            {
                if (this == null)
                    return this;
                BTreeElement temp = this;
                while (temp.parent != null)
                    temp = temp.parent;
                return temp;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public string ToPrint()
            {
                string str = null;
                int i;
                for (i = 0; i < element.Length; i++)
                {
                    if (element[i] == null)
                    {
                        if (next[i] != null)
                            str += next[i].ToPrint();
                        break;
                    }
                    if (next[i] != null)
                        str += next[i].ToPrint();
                    str += element[i].Value + " ";
                }
                if (i == next.Length && next[i] != null)
                    str += next[i].ToPrint();
                return str;
            }

            /// <summary>
            /// Add new element.
            /// </summary>
            /// <param name="newKey"> Key of new element. </param>
            /// <param name="newValue"> Value of new element. </param>
            public void Add(int newKey, ValueType newValue)
            {
                int i;
                for (i = 0; i < numberElements * 2; i++)
                {
                    if (element[i] == null)
                    {
                        if (next[i] == null)
                            element[i] = new KeyValue(newKey, newValue);
                        else
                            next[i].Add(newKey, newValue);
                        return;
                    }

                    if (newKey == element[i])
                        throw new Exception();
                    if (newKey < element[i])
                    {
                        if (next[i] == null)
                            AddToParent(newKey, newValue, null);
                        else
                            next[i].Add(newKey, newValue);
                        return;
                    }
                }

                if (next[i] == null)
                    AddToParent(newKey, newValue, null);
                else
                    next[i].Add(newKey, newValue);
                height++;
            }

            // Add new element to parent.
            private void AddToParent(int newKey, ValueType newValue, BTreeElement nextElement)
            {
                int i;
                for (i = 0; i < numberElements * 2 && element[i] != null; i++)
                { }
                if (i < numberElements * 2)
                    AddIfHasEmpty(newKey, newValue, nextElement);
                else
                {
                    if (parent != null)
                    {
                        KeyValue searchElement = SearchExtraElement(newKey, newValue);
                        if (searchElement != null)
                            parent.AddToParent(searchElement.Key
                                , searchElement.Value, AddExtraElement(nextElement));
                        else
                            parent.AddToParent(newKey, newValue, AddExtraElement(nextElement));
                    }
                    else
                    {
                        KeyValue searchElement = SearchExtraElement(newKey, newValue);
                        if (searchElement != null)
                            parent = new BTreeElement(searchElement, null, numberElements);
                        else
                            parent = new BTreeElement(newKey, newValue, null, numberElements);
                        parent.next[0] = this;
                        parent.next[1] = AddExtraElement(nextElement);
                    }
                }
            }


            /// <summary>
            /// Search extra element that you want to raise up.
            /// </summary>
            /// <param name="newKey"> New key (extra). </param>
            /// <returns> Extra element that you want to raise up.
            ///           Null, if it is newKey. </returns>
            private KeyValue SearchExtraElement(int newKey, ValueType newValue)
            {
                int i;
                for (i = 0; i < numberElements * 2 && newKey > element[i]; i++)
                { }
                if (i == numberElements)
                    return null;
                KeyValue forReturn;
                if (i <= numberElements)
                {
                    forReturn = element[numberElements - 1];
                    DeleteMiddleLeft(newKey, newValue, i);
                    // изменить - удалить средний, вставить новый.
                }
                else
                {
                    forReturn = element[numberElements];
                    DeleteMiddleRight(newKey, newValue, i);
                    // bpvybnm.
                }
                return forReturn;
            }

            private void DeleteMiddleLeft(int newKey, ValueType newValue, int position)
            {
                KeyValue temp = element[position];
                BTreeElement nextTemp = next[position];
                for (int i = position; i < numberElements; i++)
                {
                    temp = element[i];
                    nextTemp = next[i];
                    element[i] = element[i + 1];
                    next[i] = next[i + 1];
                }
            }

            private void DeleteMiddleRight(int newKey, ValueType newValue, int position)
            {
                KeyValue temp = element[numberElements];
                BTreeElement nextTemp = next[numberElements];
                for (int i = position; i < position; i++)
                {
                    temp = element[i];
                    nextTemp = next[i];
                    element[i] = element[i + 1];
                    next[i] = next[i + 1];
                }
            }

            // Return new element BTree.
            private BTreeElement AddExtraElement(BTreeElement nextElement)
            {
                BTreeElement treeElement = new BTreeElement(numberElements, parent);
                for (int i = 0; i < numberElements; i++)
                {
                    treeElement.element[i] = element[numberElements + i];
                    element[numberElements + i] = null;
                    treeElement.next[1 + i] = next[1 + numberElements + i];
                    next[1 + numberElements + i] = null;
                }
                treeElement.next[0] = nextElement;

                return treeElement;
            }

            // Add new element, if node has epmty.
            private void AddIfHasEmpty(int newKey, ValueType newValue, BTreeElement newNext)
            {
                int i;
                for (i = 0; i < 2 * numberElements && element[i] != null && newKey > element[i]; i++)
                { }
                KeyValue temp = element[i];
                BTreeElement tempNext = next[i + 1];
                int j;
                for (j = i + 1; j < 2 * numberElements && element[j] != null; j++)
                {
                    temp = element[j];
                    element[j] = temp;
                    tempNext = next[j + 1];
                    next[j + 1] = tempNext;
                }
                element[i] = new KeyValue(newKey, newValue);
                next[i + 1] = newNext;

                if (j < element.Length)
                {
                    element[j] = temp;
                    next[j + 1] = tempNext;
                }
            }

            KeyValue[] element;
            private BTreeElement[] next;
            private int height;
            private BTreeElement parent;
            private int numberElements;

            /// <summary>
            /// Class key-value.
            /// </summary>
            private class KeyValue
            {
                public KeyValue()
                { }

                public KeyValue(int newKey, ValueType newValue)
                {
                    key = newKey;
                    value = newValue;
                }

                // <
                public static bool operator <(int elementLeft, KeyValue elementRight)
                {
                    return (elementLeft < elementRight.key);
                }

                // >
                public static bool operator >(int elementLeft, KeyValue elementRight)
                {
                    return (elementLeft > elementRight.key);
                }

                // ==
                public static bool operator ==(int elementLeft, KeyValue elementRight)
                {
                    return (elementLeft == elementRight.key);
                }
                
                // !=
                public static bool operator !=(int elementLeft, KeyValue elementRight)
                {
                    return (elementLeft != elementRight.key);
                }

                /// <summary>
                /// Return key.
                /// </summary>
                public int Key
                {
                    get { return key; }
                }

                /// <summary>
                /// Return value.
                /// </summary>
                public ValueType Value
                {
                    get { return value; }
                }

                private int key;
                private ValueType value;
            }
        }

    }
}
