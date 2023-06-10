using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Tests
{
    [TestClass()]
    public class MyClassTests
    {
        [TestMethod()]
        public void SumTest()
        {
            MyClass obj = new MyClass();
            var answer = obj.Sum(1, 2);
            Assert.AreEqual(expected: 3, actual: answer);
        }
    }
}