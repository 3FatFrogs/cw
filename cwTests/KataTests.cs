using Microsoft.VisualStudio.TestTools.UnitTesting;
using cw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace cw.Tests
{
    [TestClass()]
    public class KataTests
    {
        [TestMethod()]
        public void AdditionTest()
        {
            Assert.AreNotEqual(Kata.Addition(2, 2), 5);
            Assert.AreEqual(Kata.Addition(2, 2), 4);
        }

        [TestMethod()]
        public void IsPrimeTest()
        {
            Assert.IsTrue(Kata.IsPrime(2));
            Assert.IsTrue(Kata.IsPrime(3));
            Assert.IsTrue(Kata.IsPrime(5));
            Assert.IsTrue(Kata.IsPrime(7));
            Assert.IsTrue(Kata.IsPrime(11));
            Assert.IsTrue(Kata.IsPrime(807379));
            Assert.IsTrue(Kata.IsPrime(23));
            Assert.IsTrue(Kata.IsPrime(29));
            Assert.IsTrue(Kata.IsPrime(834893));
            Assert.IsTrue(Kata.IsPrime(947));
            Assert.IsTrue(Kata.IsPrime(9973));
            Assert.IsTrue(Kata.IsPrime(835123));
            Assert.IsTrue(Kata.IsPrime(900169));
            Assert.IsTrue(Kata.IsPrime(999763));
            Assert.IsTrue(Kata.IsPrime(999769));
            Assert.IsTrue(Kata.IsPrime(999773));
            Assert.IsTrue(Kata.IsPrime(999809));
            Assert.IsTrue(Kata.IsPrime(999853));
            Assert.IsTrue(Kata.IsPrime(999863));
            Assert.IsTrue(Kata.IsPrime(999883));
            Assert.IsTrue(Kata.IsPrime(999907));
            Assert.IsTrue(Kata.IsPrime(999917));
            Assert.IsTrue(Kata.IsPrime(999931));
            Assert.IsTrue(Kata.IsPrime(999953));
            Assert.IsTrue(Kata.IsPrime(999959));
            Assert.IsTrue(Kata.IsPrime(999961));
        }

        [TestMethod()]
        public void PrimesBetweenTest()
        {
            string filePath = @"C:\Users\estomeo\Data\coding\testData\primes.txt";

            var storedResults = Utils.ReadFileByLineString(filePath).Select(int.Parse).ToList();

            var obtainedPrimes = Kata.PrimesBetween(-2, 100000);

            var set = new HashSet<int>(storedResults);

            bool equals = set.SetEquals(obtainedPrimes);

            Assert.IsTrue(equals);
        }
    }
}