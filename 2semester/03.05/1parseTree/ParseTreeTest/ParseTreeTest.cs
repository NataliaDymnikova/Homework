using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.IO;

namespace NTreeTest
{
    using _1parseTree;

    [TestClass]
    public class TreeTest
    {
        [TestInitialize]
        public void Initialize()
        {
            fInfo = new FileInfo("..//..//newFile.txt");
        }

        [TestMethod]
        public void ConstructorTest()
        {
            StreamWriter fWrite = fInfo.CreateText();
            fWrite.WriteLine("( + 1 2 )");
            fWrite.Close();
        
            fRead = fInfo.OpenText();
            Tree tree = new Tree(fRead);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionTree))]
        public void ExeptionTest()
        {
            StreamWriter fWrite = fInfo.CreateText();
            fWrite.WriteLine("( a )");
            fWrite.Close();
            
            fRead = fInfo.OpenText();
            Tree tree = new Tree(fRead);
        }

        [TestMethod]
        public void ResultTest()
        {
            StreamWriter fWrite = fInfo.CreateText();
            fWrite.WriteLine("( + 1 2 )");
            fWrite.Close();
         
            fRead = fInfo.OpenText();
            Tree tree = new Tree(fRead);
            Assert.IsTrue(tree.Result() == 3);
        }

        [TestMethod]
        public void HardResultTest()
        {
            StreamWriter fWrite = fInfo.CreateText();
            fWrite.WriteLine("( + 1 ( * ( / 6 3 ) ( + 2 3 ) ) )");
            fWrite.Close();

            fRead = fInfo.OpenText();
            Tree tree = new Tree(fRead);
            Assert.IsTrue(tree.Result() == (5 - 4 + 6 / 3 * (2 + 3)));
        }

        [TestCleanup]
        public void Clean()
        {
            fRead.Close();
            fInfo.Delete();
        }

        private FileInfo fInfo;
        private StreamReader fRead; 
    }
}
