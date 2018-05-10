using System;
using System.Collections.Generic;



namespace cw
{
    public class Kata
    {
        public static double Addition(double a, double b)
        {
            return a + b;
        }
    }

    public class Fibonacci : Kata
    {
        public static bool IsFibonacci(long x)
        {
            if (x < 0)
                return false;

            long pippo = 5 * x * x + 4;


            if (Utils.IsPerfectSquare(5 * x * x + 4))
                return true;

            else if (Utils.IsPerfectSquare(5 * x * x - 4))
                return true;

            return false;

        }

        public static List<ulong> CalculateFirstNFibonacci(int n)
        {
            List<ulong> fib = new List<ulong>();
            ulong fn1 = 0;
            ulong fn2 = 0;
            ulong fn = 0;
            for (int i = 0; i <= n; i++)
            {
                if (i == 0)
                {
                    fn1 = 0;
                    fn2 = 0;
                }

                if ((i == 1) || (i == 2))
                {
                    fn1 = 1;
                    fn2 = 0;
                }

                if (i > 2)
                {
                    fn2 = fn1;
                    fn1 = fn;
                }
                fn = fn1 + fn2;
                fib.Add(fn);
            }

            return fib;
        }

        public static long GetFibonacciRecursive(int n)
        {
            if (n <= 0)
                return 0;

            if (n == 1)
                return 1;

            return GetFibonacciRecursive(n - 1) + GetFibonacciRecursive(n - 2);
        }

        public static long GetFibonacciIterative(int n)
        {

            long Fn_Minus1 = 0;
            long Fn = 0;
            long Fn_Plus1 = 1;

            for (int i = 0; i <n ; ++i)
            {
                Fn_Minus1 = Fn;
                Fn = Fn_Plus1;
                Fn_Plus1 = Fn + Fn_Minus1;
            }

            return Fn;
        }
    }


    public class Prime : Kata
    {
        public static List<int> PrimesBetween(int start, int end)
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
