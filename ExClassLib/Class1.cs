using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using ExcelDna.Integration;
using cw;

namespace ExClassLib
{
    public class Class1
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static double EuropeanCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            Options european = new Options();
            return european.EuropeanCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
        }

        public static double GetDeltaCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            Options european = new Options();
            return european.GetDeltaCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
        }

        public static double GetGammaCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            Options european = new Options();
            return european.GetGammaCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
        }


        public static double GetVegaCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            Options european = new Options();
            return european.GetVegaCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
        }


        public static double GetThetaCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            Options european = new Options();
            return european.GetThetaCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
        }

        public static double GetRhoCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            Options european = new Options();
            return european.GetRhoCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
        }

    }
}
