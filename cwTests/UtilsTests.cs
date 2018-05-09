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

    }
}