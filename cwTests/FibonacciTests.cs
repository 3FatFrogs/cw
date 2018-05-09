using Microsoft.VisualStudio.TestTools.UnitTesting;
using cw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw.Tests
{
    [TestClass()]
    public class FibonacciTests
    {
        [TestMethod()]
        public void IsFibonacciTest()
        {
            Assert.IsFalse(Fibonacci.IsFibonacci(-1));
            Assert.IsFalse(Fibonacci.IsFibonacci(4));
            Assert.IsTrue(Fibonacci.IsFibonacci(0));
            Assert.IsTrue(Fibonacci.IsFibonacci(1));
            Assert.IsTrue(Fibonacci.IsFibonacci(2));
            Assert.IsTrue(Fibonacci.IsFibonacci(3));
            Assert.IsTrue(Fibonacci.IsFibonacci(5));
            Assert.IsTrue(Fibonacci.IsFibonacci(8));
            Assert.IsTrue(Fibonacci.IsFibonacci(6765));
            Assert.IsTrue(Fibonacci.IsFibonacci(28657));
            Assert.IsTrue(Fibonacci.IsFibonacci(39088169));
            //Assert.IsTrue(Fibonacci.IsFibonacci(139583862445));


        }

        //[TestMethod()]
        //public void CalculateFirstNFibonacciTest()
        //{
            //Dictionary<int, long> storedFib = new Dictionary<int, long>();
            //var test2 = Fibonacci.CalculateFirstNFibonacci(100);
        //}

        [TestMethod()]
        public void GetFibonacciIterativeTest()
        {
            Assert.AreEqual(0, Fibonacci.GetFibonacciIterative(-4));
            Assert.AreEqual(0, Fibonacci.GetFibonacciIterative(0));
            Assert.AreEqual(377, Fibonacci.GetFibonacciIterative(14));
            Assert.AreEqual(14930352, Fibonacci.GetFibonacciIterative(36));
            Assert.AreEqual(433494437, Fibonacci.GetFibonacciIterative(43));
            Assert.AreEqual(1836311903, Fibonacci.GetFibonacciIterative(46));
            Assert.AreEqual(5527939700884757, Fibonacci.GetFibonacciIterative(77));
            Assert.AreEqual(99194853094755497, Fibonacci.GetFibonacciIterative(83));
            Assert.AreEqual(4660046610375530309, Fibonacci.GetFibonacciIterative(91));
        }

        [TestMethod()]
        public void GetFibonacciRecursiveTest()
        {
            Assert.AreEqual(0, Fibonacci.GetFibonacciRecursive(-4));
            Assert.AreEqual(0, Fibonacci.GetFibonacciRecursive(0));
            Assert.AreEqual(377, Fibonacci.GetFibonacciRecursive(14));
            Assert.AreEqual(14930352, Fibonacci.GetFibonacciRecursive(36));
            Assert.AreEqual(433494437, Fibonacci.GetFibonacciRecursive(43));
            Assert.AreEqual(1836311903, Fibonacci.GetFibonacciRecursive(46));
        }
    }
}