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
    public class PrimeTests
    {
        [TestMethod()]
        public void IsPrimeTest()
        {
            Assert.IsTrue(Prime.IsPrime(2));
            Assert.IsTrue(Prime.IsPrime(3));
            Assert.IsTrue(Prime.IsPrime(5));
            Assert.IsTrue(Prime.IsPrime(7));
            Assert.IsTrue(Prime.IsPrime(11));
            Assert.IsTrue(Prime.IsPrime(807379));
            Assert.IsTrue(Prime.IsPrime(23));
            Assert.IsTrue(Prime.IsPrime(29));
            Assert.IsTrue(Prime.IsPrime(834893));
            Assert.IsTrue(Prime.IsPrime(947));
            Assert.IsTrue(Prime.IsPrime(9973));
            Assert.IsTrue(Prime.IsPrime(835123));
            Assert.IsTrue(Prime.IsPrime(900169));
            Assert.IsTrue(Prime.IsPrime(999763));
            Assert.IsTrue(Prime.IsPrime(999769));
            Assert.IsTrue(Prime.IsPrime(999773));
            Assert.IsTrue(Prime.IsPrime(999809));
            Assert.IsTrue(Prime.IsPrime(999853));
            Assert.IsTrue(Prime.IsPrime(999863));
            Assert.IsTrue(Prime.IsPrime(999883));
            Assert.IsTrue(Prime.IsPrime(999907));
            Assert.IsTrue(Prime.IsPrime(999917));
            Assert.IsTrue(Prime.IsPrime(999931));
            Assert.IsTrue(Prime.IsPrime(999953));
            Assert.IsTrue(Prime.IsPrime(999959));
            Assert.IsTrue(Prime.IsPrime(999961));
        }

        [TestMethod()]
        public void PrimesBetweenTest()
        {
            List<int> obtainedPrimes = Prime.PrimesBetween(-2, 100000);

            //compare two Lists
            var set = new HashSet<int>(ListOfPrimesUpTo10k());           

            bool equals = set.SetEquals(obtainedPrimes);

            Assert.IsTrue(equals);
        }

        [DeploymentItem("prime.txt")]
        public List<int> ListOfPrimesUpTo10k()
        {           
            string filePath = @"TestFiles\primes.txt";
            return Utils.ReadFileByLineString(filePath).Select(int.Parse).ToList();
        }
    }
}