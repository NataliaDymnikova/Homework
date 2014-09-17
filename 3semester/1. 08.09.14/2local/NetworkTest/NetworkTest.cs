using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetworkTest
{
    using _2local;
    using System.IO;

    [TestClass]
    public class NetworkTest
    {
        [TestInitialize]
        public void Initialize()
        {
            StreamWriter writer = new StreamWriter(nameFile);
            writer.Write("3" + '\n'
                        + "1 1 0" + '\n'
                        + "1 1 1"  + '\n'
                        + "0 1 1" + '\n'
                        + "2" + '\n'
                        + "os 100" + '\n'
                        + "mac 20" + '\n'
                        + "1 mac" + '\n'
                        + "2 os" + '\n'
                        + "3 os" + '\n'
                        + "2");
            writer.Close();

            network = new Network(nameFile);
            result = network.Run().Split('\n');
        }

        [TestMethod]
        public void SimpleTest()
        {
            Assert.IsTrue(result[0] == "2 ");
            Assert.IsTrue(result[1].Contains("2 3"));
            Assert.IsTrue(result[result.Length - 1] == "1 2 3 ");
        }

        [TestCleanup]
        public void DeleteFile()
        {
            File.Delete(nameFile);
        }

        private Network network;
        private string[] result;
        private string nameFile = "testIn.txt";
    }
}
