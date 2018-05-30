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
    public class NumericalMethodsTests
    {
        [TestMethod()]
        public void IntegralSimpsonTest()
        {
            int steps = 4096*2;
            double tolerance = 0.0001;

            Func<double, double> f1 = (x => Math.Exp(-x) * Math.Cos(x));
            Func<double, double> f2 = (x => x = 1 / (1 + x * 2));

            Assert.AreEqual(0.499066278634146, NumericalMethods.IntegralSimpson(0, 2 * Math.PI, steps, f1), tolerance);
            Assert.AreEqual(0.9729550745276567, NumericalMethods.IntegralSimpson(1, 10, steps, f2), tolerance);
        }

        [TestMethod()]
        public void IntegralTrapezoidalTest()
        {
            int steps = 4096*2;
            double tolerance = 0.0001;
            Func<double, double> f1 = (x => Math.Exp(-x) * Math.Cos(x));
            Func<double, double> f2 = (x => x = 1 / (1 + x * 2));

            Assert.AreEqual(0.499066278634146, NumericalMethods.IntegralTrapezoidal(0, 2 * Math.PI, steps, f1), tolerance);
            Assert.AreEqual(0.9729550745276567, NumericalMethods.IntegralTrapezoidal(1, 10, steps, f2), tolerance);

        }
    }
}