using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace RobotsTest
{
    using _1robots;

    /// <summary>
    /// Test of robots which can jump and die.
    /// </summary>
    [TestClass]
    public class RobotsTest
    {
        [TestInitialize]
        public void Initialize()
        {
            writer = new StreamWriter(nameFile);
            writer.WriteLine("11");
            writer.WriteLine("0 1 0 0 0 0 0 0 0 0 0");
            writer.WriteLine("1 0 1 0 0 0 0 0 0 0 0");
            writer.WriteLine("0 1 0 1 0 0 0 0 0 0 0");
            writer.WriteLine("0 0 1 0 1 0 0 0 0 0 0");
            writer.WriteLine("0 0 0 1 0 1 0 0 0 0 0");
            writer.WriteLine("0 0 0 0 1 0 1 0 0 0 0");
            writer.WriteLine("0 0 0 0 0 1 0 1 0 0 0");
            writer.WriteLine("0 0 0 0 0 0 1 0 1 0 0");
            writer.WriteLine("0 0 0 0 0 0 0 1 0 1 0");
            writer.WriteLine("0 0 0 0 0 0 0 0 1 0 1");
            writer.WriteLine("0 0 0 0 0 0 0 0 0 1 0");
        }

        [TestMethod]
        public void TrueTest()
        {
            writer.WriteLine("1 7");
            writer.Close();
            robots = new Robots(nameFile);
            Assert.IsTrue(robots.Run());
        }

        [TestMethod]
        public void FalseTest()
        {
            writer.WriteLine("1 2 7");
            writer.Close();
            robots = new Robots(nameFile);
            Assert.IsFalse(robots.Run());
        } 

        [TestMethod]
        public void HardTest()
        {
            writer.WriteLine("1 2 11 8 4");
            writer.Close();
            robots = new Robots(nameFile);
            Assert.IsTrue(robots.Run());
        }

        [TestCleanup]
        public void DeleteFile()
        {
            File.Delete(nameFile);
        }

        private string nameFile = "testIn.txt";
        private StreamWriter writer;
        private Robots robots;   
    }
}
