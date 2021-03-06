﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
            NumericalMethods.SolveQuadraticEquation(16, 4, -1, ref sol1, ref sol2);

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

            Assert.AreEqual(0.499066278634146, NumericalMethods.IntegralSimpson(0, 2 * Math.PI, steps, f1, tolerance), tolerance);
            Assert.AreEqual(0.9729550745276567, NumericalMethods.IntegralSimpson(1, 10, steps, f2, tolerance), tolerance);
        }

        [TestMethod()]
        public void NewtonMethodTest()
        {
            double tolerance = 0.00000000000001;
            double initialValue = 0.25;
            int maxNumberofSteps = 100;

            Func<double, double> f = (x => 2 * Math.Cos(x) - 3 * x);
            Func<double, double> g = (x => -2 * Math.Sin(x) - 3);
            Assert.AreEqual(0.5635692042255156424905, NumericalMethods.NewtonMethod(f, g, initialValue, maxNumberofSteps), tolerance);

            f = (x => 5 * x * x - 3);
            g = (x => 10 * x);
            Assert.AreEqual(0.774596669241483377, NumericalMethods.NewtonMethod(f, g, initialValue, maxNumberofSteps), tolerance);
        }

        [TestMethod()]
        public void BisectionMethodTest()
        {
            int maxIterations = 2000;
            double delta = 0.00000000000001;

            Func<double, double> f = (x => 2 * Math.Cos(x) - 3 * x);
            Assert.AreEqual(0.5635692042255156424905, NumericalMethods.BisectionMethod(f, -10, 10), delta);

            f = (x => 5 * x - 3);
            Assert.AreEqual(0.6, NumericalMethods.BisectionMethod(f, -50, 50), delta);

            f = (x => x - Math.Exp(-x));
            Assert.AreEqual(0.567143290409783872, NumericalMethods.BisectionMethod(f, -10, 10, maxIterations, 1E-19), delta);
        }

        [TestMethod()]
        public void SlopeTest()
        {
            Assert.AreEqual(0.5, NumericalMethods.Slope((x => 0.5 * x + 2), 6, 2));
        }

        [TestMethod()]
        public void RegulaFalseMethodTest()
        {
            int maxIterations = 200;
            double delta = 0.00000000000001;

            Func<double, double> f = (x => 2 * Math.Cos(x) - 3 * x);
            System.Diagnostics.Trace.WriteLine("===========================");
            Assert.AreEqual(0.5635692042255156424905, NumericalMethods.RegulaFalseMethod(f, -10, 10, maxIterations), delta);

            System.Diagnostics.Trace.WriteLine("===========================");
            f = (x => 5 * x - 3);
            Assert.AreEqual(0.6, NumericalMethods.RegulaFalseMethod(f, -50, 50, maxIterations, 1E-6), delta);

            System.Diagnostics.Trace.WriteLine("===========================");
            f = (x => x - Math.Exp(-x));
            Assert.AreEqual(0.567143290409783872, NumericalMethods.RegulaFalseMethod(f, -1, 1, maxIterations, 1E-19), delta);
        }

        [TestMethod()]
        public void FindAllFactorsTest()
        {
            List<int> factors1 = new List<int>() { 1, 2, 3, 4, 6, 12 };
            Assert.IsTrue(Enumerable.SequenceEqual(NumericalMethods.FindAllFactors(12).OrderBy(x => x), factors1.Select(x => -x).Union(factors1).ToList().OrderBy(x => x)));

            List<int> factors2 = new List<int>() { 1, 7, 13, 91, 97, 679, 739, 1261, 5173, 8827, 9607, 67249, 71683, 501781, 931879, 6523153 };
            Assert.IsTrue(Enumerable.SequenceEqual(NumericalMethods.FindAllFactors(6523153).OrderBy(x => x), factors2.Select(x => -x).Union(factors2).ToList().OrderBy(x => x)));

            List<int> factors3 = new List<int>() { 1, 3, 9 };
            Assert.IsTrue(Enumerable.SequenceEqual(NumericalMethods.FindAllFactors(9).OrderBy(x => x), factors3.Select(x => -x).Union(factors3).ToList().OrderBy(x => x)));
        }

        [TestMethod()]
        public void RationalRootsTestTest()
        {
            List<double> correctRoots = new List<double>() { 2, 3, -3, -5, 7, -8 }.OrderBy(x => x).ToList();

            int[] coefficients = new int[] { 1, 4, -72, -214, 1127, 1602, -5040 };
            Array.Reverse(coefficients);

            var result = NumericalMethods.RationalRootsTest(coefficients).OrderBy(x=>x);
            Assert.IsTrue(Enumerable.SequenceEqual(result, correctRoots));
        }
    }
}