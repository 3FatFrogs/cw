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

    }
}
