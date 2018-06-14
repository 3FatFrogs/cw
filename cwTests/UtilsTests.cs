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
    public class UtilsTests
    {
        private TestContext testContextInstance;

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod()]
        public void IsPerfectSquareTest()
        {
            Assert.IsFalse(Utils.IsPerfectSquare(-9));
            Assert.IsTrue(Utils.IsPerfectSquare(0));
            Assert.IsTrue(Utils.IsPerfectSquare(1));
            Assert.IsFalse(Utils.IsPerfectSquare(2));
            Assert.IsTrue(Utils.IsPerfectSquare(4));
            Assert.IsTrue(Utils.IsPerfectSquare(9));
            Assert.IsTrue(Utils.IsPerfectSquare(1369));
            Assert.IsTrue(Utils.IsPerfectSquare(3481));

            //long x = 99990000999999;
            //Assert.IsTrue(Utils.IsPerfectSquare(x * x));
        }

        [TestMethod()]
        public void IsPerfectSquare2Test()
        {
            Assert.IsFalse(Utils.IsPerfectSquare(-9));
            Assert.IsTrue(Utils.IsPerfectSquare(0));
            Assert.IsTrue(Utils.IsPerfectSquare(1));
            Assert.IsFalse(Utils.IsPerfectSquare(2));
            Assert.IsTrue(Utils.IsPerfectSquare(4));
            Assert.IsTrue(Utils.IsPerfectSquare(9));
            Assert.IsTrue(Utils.IsPerfectSquare(1369));
            Assert.IsTrue(Utils.IsPerfectSquare(3481));
            Assert.IsTrue(Utils.IsPerfectSquare(49));

            //long x = 99990000999999;
            //Assert.IsTrue(Utils.IsPerfectSquare(x*x));
        }

        [TestMethod()]
        public void NewtonSqrtTest()
        {
            double x = 546518548456461;
            double tolerance = 0.00000000000000005;
            Assert.AreEqual(Utils.NewtonSqrt(x, tolerance), Math.Sqrt(x), 0.000000000001);
        }

        [TestMethod()]
        public void ReverseStringv1Test()
        {
            var str = "£$%^&*()_+QWERTYUIOP{}1234567890";
            var str2 = "0987654321}{POIUYTREWQ+_)(*&^%$£";

            for (int i = 0; i < 15; i++)
            {
                str += str;
                str2 += str2;
            }

            Assert.AreEqual(Utils.ReverseStringv1(str), str2);
        }

        [TestMethod()]
        public void ReverseStringv2Test()
        {
            var str = "1234567890";
            var str2 = "0987654321";
            Assert.AreEqual(Utils.ReverseStringv2(str), str2);
        }


        [TestMethod()]
        public void DecimalToBinTest()
        {
            TestContext.WriteLine("=== DecimalToBinTest ==== ");
            Assert.AreEqual(Utils.DecimalToBin(-3), "");
            Assert.AreEqual(Utils.DecimalToBin(0), "0");
            Assert.AreEqual(Utils.DecimalToBin(1), "1");
            Assert.AreEqual(Utils.DecimalToBin(4), "100");
            Assert.AreEqual(Utils.DecimalToBin(19), "10011");
            //Assert.AreEqual(Utils.DecimalToBin(15465749654654654), "110110111100100000010001110010010110011100111010111110");
        }


        [TestMethod()]
        public void DecimalToBin2Test()
        {
            TestContext.WriteLine("=== DecimalToBinTest ==== ");

            Assert.AreEqual(Utils.DecimalToBin2(-3), "");
            Assert.AreEqual(Utils.DecimalToBin2(0), "0");
            Assert.AreEqual(Utils.DecimalToBin2(1), "1");
            Assert.AreEqual(Utils.DecimalToBin2(4), "100");
            Assert.AreEqual(Utils.DecimalToBin2(19), "10011");
            //Assert.AreEqual(Utils.DecimalToBin2(15465749654654654), "110110111100100000010001110010010110011100111010111110");

        }

        [TestMethod()]
        public void FactorialRecursiveTest()
        {
            Assert.AreEqual(Utils.FactorialRecursive(19), 121645100408832000);
        }

        [TestMethod()]
        public void FactorialIterativeTest()
        {
            Assert.AreEqual(Utils.FactorialIterative(19), 121645100408832000);
        }

        [TestMethod()]
        public void NegateTest()
        {
            int i = 4;
            Assert.AreEqual(-4, Utils.Negate(i));
        }

        [TestMethod()]
        public void ConvertListToStringTest()
        {
            List<int> listInt = new List<int> { 1, 2, 3, 4 };
            Assert.AreEqual("1234", Utils.ConvertListToString(listInt));
        }
    }
}