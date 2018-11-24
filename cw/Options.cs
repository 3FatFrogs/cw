using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw
{
    public class Options
    {
        //private double currentPrice; //spot
        //private double strikePrice;
        //private double sigma;
        //private double timeToMaturity;
        //private double interestRate;  //the interest free rate
        //private double dividend;  //continuous dividend yield

        //public Options(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        //{
        //    this.currentPrice = currentPrice;
        //    this.strikePrice = strikePrice;
        //    this.sigma = sigma;
        //    this.timeToMaturity = timeToMaturity/365;
        //    this.interestRate = interestRate;
        //    this.dividend = dividend;
        //}


        public Options() { }

        public double GetCallPayoff(double spot, double strike) => (spot > strike) ? spot - strike : 0.0;
        public double GetPutPayoff(double spot, double strike) => (spot < strike) ? 0.0 : spot - strike;

        public double EuropeanCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            timeToMaturity = timeToMaturity / 365;
            double d1 = GetD1(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            double d2 = GetD2(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);

            return currentPrice * MathUtils.NormalDistribution(d1) - strikePrice * Math.Exp(-interestRate * timeToMaturity) * MathUtils.NormalDistribution(d2);
        }

        public double GetDeltaCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            timeToMaturity /= 365;
            double d1 = GetD1(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            return MathUtils.NormalDistribution(d1);
        }

        public double GetGammaCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            timeToMaturity /= 365;
            double d1 = GetD1(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            return MathUtils.StandardNormalDistribution(d1) / (currentPrice * sigma * Math.Sqrt(timeToMaturity));
        }

        public double GetVegaCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            timeToMaturity /= 365;
            double d1 = GetD1(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            return currentPrice * Math.Exp(-0.5 * d1 * d1) / (Math.Sqrt(timeToMaturity * 2 * Math.PI)) / 100;
        }

        public double GetThetaCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            timeToMaturity = timeToMaturity / 365;
            double d1 = GetD1(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            double d2 = GetD2(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);

            var firstTerm = -currentPrice * MathUtils.StandardNormalDistribution(d1) * sigma / (2 * Math.Sqrt(timeToMaturity));
            var secondTerm = interestRate * strikePrice * Math.Exp(-interestRate * timeToMaturity) * MathUtils.NormalDistribution(d2);

            return (firstTerm - secondTerm) / 365;
        }

        public double GetRhoCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            timeToMaturity /= 365;
            double d2 = GetD2(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
            return currentPrice * timeToMaturity * Math.Exp(-interestRate * timeToMaturity) * MathUtils.NormalDistribution(d2) / 100;
        }

        public double EuropeanPut()
        {
            throw new NotImplementedException();
        }

        public double GetD1(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            return (1 / sigma * Math.Sqrt(timeToMaturity)) * (Math.Log(currentPrice / strikePrice) + (interestRate + sigma * sigma * 0.5) * timeToMaturity);
        }

        public double GetD2(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            return (1 / sigma * Math.Sqrt(timeToMaturity)) * (Math.Log(currentPrice / strikePrice) + (interestRate - sigma * sigma * 0.5) * timeToMaturity);
        }
    }
}
