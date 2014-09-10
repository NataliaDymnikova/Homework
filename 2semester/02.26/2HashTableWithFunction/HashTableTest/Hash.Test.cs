using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hash.Test
{
    using _2HashTableWithFunction;
   
    /// <summary>
    /// Test Hash table. 
    /// </summary>
    [TestClass]
    public class HashTest
    {
        [TestInitialize]
        public void Initialize()
        {
            hash = new HashTable(5, new HashFunctionClass1());
        }

        [TestMethod]
        public void AddToHashTableTest()
        {
            hash.AddToHashTable(1);
            Assert.IsTrue(hash.Exist(1));
        }

        [TestMethod]
        public void DeleteElementTest()
        {
            hash.AddToHashTable(1);
            hash.DeleteElement(1);
            Assert.IsFalse(hash.Exist(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionHash))]
        public void DeleteElementInEmptyHashTest()
        {
            hash.DeleteElement(1);
        }

        [TestMethod]
        public void ChangeHashFunctionTest()
        {
            hash.AddToHashTable(1);
            hash.AddToHashTable(2);
            hash.AddToHashTable(3);
            hash.ChangeHashFunction(new HashFunctionClass0());
            Assert.IsTrue(hash.Exist(1)); 
            Assert.IsTrue(hash.Exist(2)); 
            Assert.IsTrue(hash.Exist(3));
        }

        private HashTable hash;
    }
}
