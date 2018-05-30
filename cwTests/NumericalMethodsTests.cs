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
            int steps = Convert.ToInt32(Math.Pow(2, 10));
            double tolerance = 0.0000001;

            Func<double, double> f1 = (x => Math.Exp(-x) * Math.Cos(x));
            Func<double, double> f2 = (x => x = 1 / (1 + x * 2));

            Assert.AreEqual(0.499066278634146, NumericalMethods.IntegralSimpson(0, 2 * Math.PI, steps, f1), tolerance);
            Assert.AreEqual(0.9729550745276567, NumericalMethods.IntegralSimpson(1, 10, steps, f2), tolerance);
        }

        [TestMethod()]
        public void IntegralTrapezoidalTest()
        {
            int steps = Convert.ToInt32(Math.Pow(2, 13));
            double tolerance = 0.0000001;
            Func<double, double> f1 = (x => Math.Exp(-x) * Math.Cos(x));
            Func<double, double> f2 = (x => x = 1 / (1 + x * 2));

            Assert.AreEqual(0.499066278634146, NumericalMethods.IntegralTrapezoidal(0, 2 * Math.PI, steps, f1), tolerance);
            Assert.AreEqual(0.9729550745276567, NumericalMethods.IntegralTrapezoidal(1, 10, steps, f2), tolerance);

        }

        [TestMethod()]
        public void QuadraticEquationTest()
        {
            double tol = 0.0000001;
            double sol1 = 0;
            double sol2 = 0;
            NumericalMethods.QuadraticEquation(16, 4, -1, ref sol1, ref sol2);

            Assert.AreEqual(0.15450849718747373, sol1, tol);
            Assert.AreEqual(-0.4045084971874737, sol2, tol);
        }

        [TestMethod()]
        public void IntegralSimpsonTest1()
        {
            int steps = int.MaxValue;
            double tolerance = 0.00001;

            Func<double, double> f1 = (x => Math.Exp(-x) * Math.Cos(x));
            Func<double, double> f2 = (x => x = 1 / (1 + x * 2));

            Assert.AreEqual(0.499066278634146, NumericalMethods.IntegralSimpson(0, 2 * Math.PI, steps, f1,tolerance), tolerance);
            Assert.AreEqual(0.9729550745276567, NumericalMethods.IntegralSimpson(1, 10, steps, f2, tolerance), tolerance);
        }
    }
}