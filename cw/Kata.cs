using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw
{
    public class Kata
    {
        public static double Addition(double a, double b)
        {
            return a + b;
        }

        public static List<int> PrimesBetween(int start, int end)
        {
            List<int> x = new List<int>();
            for (int i = start; i < end; i++)
                if (IsPrime(i))
                    x.Add(i);
            return x;
        }

        public List<int> PrimesBetween2(int start, int end)
        {
            List<int> x = new List<int>();
            for (int i = start; i < end; i++)
                if (IsPrime(i))
                    x.Add(i);
            return x;
        }


        public static bool IsPrime(int x)
        {
            if (x < 2)
                return false;

            if (x < 4)
                return true;

            for (int i = 2; i < x - 1; i++)
            {
                if ((x % i) == 0)
                    return false;
            }

            return true;
        }
    }
}
