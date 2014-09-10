using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculateTestNamespace
{
    using _1calculator;
    [TestClass]
    public class CalculateTest
    {
        [TestInitialize]
        public void Initialize()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void AddNumberTest()
        {
            calculator.Add(5);
            Assert.AreEqual(calculator.Print(), "5");
        }
        
        [TestMethod]
        public void AddSignToEmptyStackTest()
        {
            calculator.Add('+');
            Assert.AreEqual(calculator.Print(), null);
        }

        [TestMethod]
        public void AddSignTest()
        {
            calculator.Add(5);
            calculator.Add('+');
            Assert.AreEqual(calculator.Print(), "5+");
        }

        [TestMethod]
        public void CalculatorTest()
        {
            calculator.Add(5);
            calculator.Add('+');
            calculator.Add(2);
            calculator.Add('=');
            Assert.AreEqual(calculator.Print(), "7=");
        }
        
        [TestMethod]
        public void CalculateSomeOperationTest()
        {
            calculator.Add(5);
            calculator.Add('+');
            calculator.Add(2);
            calculator.Add('/');
            calculator.Add(7);
            calculator.Add('=');
            Assert.AreEqual(calculator.Print(), "1=");
        }

        [TestMethod]
        public void DelenieNaNolTest()
        {
            calculator.Add(2);
            calculator.Add('/');
            calculator.Add(0);
            calculator.Add('=');
            Assert.AreEqual(calculator.Print(), "0=");
        }

        private Calculator calculator;
    }
}
