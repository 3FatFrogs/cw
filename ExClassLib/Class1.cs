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

        public static double GetDeltaCall(double currentPrice, double strikePrice, double sigma, double timeToMaturity, double interestRate, double dividend)
        {
            Options european = new Options();
            return european.GetDeltaCall(currentPrice, strikePrice, sigma, timeToMaturity, interestRate, dividend);
        }

    }
}
