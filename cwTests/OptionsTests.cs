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
    public class OptionsTests
    {
        private double currentPrice = 100; //Underlying Price
        private double strikePrice = 100.0;  //Exercise Price
        private double sigma = 0.25;         //Volatility
        private double timeToMaturity = 30; //Days Until Expiration
        private double interestRate = 0.05;  //the interest free rate
        private double dividend = 0;  //continuous dividend yield
        private double delta = 0.001;

        private Options european = new Options();

        [TestMethod()]
        public void GetCallPayoffTest()
        {
            var pay1 = european.GetCallPayoff(150, 100);
            Assert.AreEqual(50, pay1);
        }

        [TestMethod()]
        public void EuropeanCallTest()
        {
            var v = european.EuropeanCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            Assert.AreEqual(3.063, v, delta);
        }

        [TestMethod()]
        public void GetDeltaCallTest()
        {
            var v = european.GetDeltaCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            Assert.AreEqual(0.5374, v, delta);

        }

        [TestMethod()]
        public void GetGammaCallTest()
        {
            var v = european.GetGammaCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            Assert.AreEqual(0.05542, v, delta);
        }

        [TestMethod()]
        public void GetVegaCallTest()
        {
            var v = european.GetVegaCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            Assert.AreEqual(0.11388, v, delta);
        }

        [TestMethod()]
        public void GetThetaCallTest()
        {
            var v = european.GetThetaCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            Assert.AreEqual(-0.05439, v, delta);
        }

        [TestMethod()]
        public void GetRhoCallTest()
        {
            var v = european.GetRhoCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            Assert.AreEqual(0.04163, v, delta);
        }
    }
}