using System;
using NList;

using ElementType = System.Int32;

namespace _2HashTableWithFunction
{
    /// <summary>
    /// This class keep elemenets in hash table.
    /// </summary>
    public class HashTable
    {
        public HashTable(int size)
        {
            Init(size);
            hashFunction = new HashFunctionClass0();
        }
        
        /// <summary>
        /// Constructor with size hash table and number hash function. 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="numberFunction"></param>
        public HashTable(int size, HashFunctionInterface func)
        {
            Init(size);
            hashFunction = func;
        }

        /// <summary>
        /// Add element to hash table with value newElement.  
        /// </summary>
        /// <param name="newElement"></param>
        public void AddToHashTable(ElementType newElement)
        {
            if (Exist(newElement))
            {
                Console.WriteLine("Element exist");
                return;
            }
            bucket[hashFunction.Function(newElement) % bucket.Length].AddElementToHead(newElement);
        }

        /// <summary>
        /// Delete element wit value deleteElemenet. 
        /// </summary>
        /// <param name="deleteElement"></param>
        public void DeleteElement(ElementType deleteElement)
        {
            if (!Exist(deleteElement))
                throw new ExceptionHash("Delete element don't exist.");

            bucket[hashFunction.Function(deleteElement) % bucket.Length].DeleteElement(deleteElement);
        }
        
        /// <summary>
        /// Return tru or false: exist element with value element. 
        /// </summary>
        /// <param name="element"></param>
        /// <returns> Exist element or not </returns>
        public bool Exist(ElementType element)
        {
            return bucket[hashFunction.Function(element) % bucket.Length].Exist(element);
        }

        /// <summary>
        /// Print hash table. 
        /// </summary>
        public void PrintHash()
        {
            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i].Print();
            }
        }
        
        /// <summary>
        /// Function to change hash function without delete elements
        /// </summary>
        /// <param name="func"></param>
        public void ChangeHashFunction(HashFunctionInterface func)
        {
            List[] temp = new List[bucket.Length];
            for (int i = 0; i < bucket.Length; i++)
                temp[i] = new List();
            
            for (int i = 0; i < bucket.Length; i++)
            {
                while (!bucket[i].IsEmpty())
                {
                    temp[func.Function(bucket[i].ValueHead()) % temp.Length]
                        .AddElementToHead(bucket[i].ValueHead());
                    bucket[i].DeleteElement(bucket[i].ValueHead());
                }
            }
            hashFunction = func;
            bucket = temp;
        }

        // Initialize bucket.
        private void Init(int size)
        {
            bucket = new List[size];
            for (int i = 0; i < size; i++)
                bucket[i] = new List();
        }

        private List[] bucket;
        private HashFunctionInterface hashFunction;
        
    }
}
