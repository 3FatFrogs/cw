using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cw
{
    public class Kata
    {
        public static double Addition(int a, int b)
        {
            if (b == 0)
                return a;

            int sum = a ^ b; //xor

            int carry = (a & b) << 1;

            return Addition(sum, carry);
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

            for (int i = 0; i < n; ++i)
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

    public class Sorting : Kata
    {
        public static void BubbleSort(int[] x)
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < x.Length - 1; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        swapped = true;
                        Utils.SwapElementsInArray(i, i + 1, x);
                    }
                }
            }
        }

        public static void SelectionSort(int[] x)
        {
            int posMin;
            for (int i = 0; i < x.Length - 1; i++)
            {
                posMin = i;
                for (int j = i + 1; j < x.Length; j++)
                {
                    if (x[j] < x[posMin])
                        posMin = j;
                }

                if (i != posMin)
                    Utils.SwapElementsInArray(i, posMin, x);
            }
        }

        public static void InsertionSort(int[] x, int gap = 1)
        {
            if (gap < 1)
                throw new ArgumentOutOfRangeException();

            for (int i = gap; i < x.Length; i++)
            {
                for (int j = i; j - gap >= 0 && (x[j] < x[j - gap]); j = j - gap)
                {
                    Utils.SwapElementsInArray(j, j - gap, x);
                }
            }
        }

        public static void ShellSort(int[] a, List<int> gaps)
        {
            foreach (int gap in gaps)
            {
                InsertionSort(a, gap);
            }
        }

        public static void QuickSort(int[] x, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partion(x, lo, hi);
                QuickSort(x, lo, p - 1);
                QuickSort(x, p + 1, hi);
            }
        }

        public static int Partion(int[] A, int lo, int hi)
        {
            int pivot = A[hi];

            for (int j = lo; j < hi; j++)
            {
                if (A[j] < A[hi])
                    Utils.SwapElementsInArray(lo++, j, A);
            }

            Utils.SwapElementsInArray(lo, hi, A);
            return lo;
        }

    }

    public class Exercises : Kata
    {
        /* Write a method to decide if two strings are anagrams or not.*/
        public static bool AreAnagrams(string a, string b)
        {
            //remove spaces and sort
            a = new string(a.ToList().Where(x => x != ' ').Select(x => x).OrderBy(x => x).ToArray());
            b = new string(b.ToList().Where(x => x != ' ').Select(x => x).OrderBy(x => x).ToArray());

            if (a.Length == b.Length)
            {
                if (a.SequenceEqual(b))
                    return true;
                else
                    return false;
            }

            return false;
        }

        //Write a method to replace all spaces in a string with a char passed as argument
        public static string ReplaceAllSpaceWith(string str, char filler)
        {
            return new string(str.Select(x => x == ' ' ? filler : x).ToArray());
        }


        /* You have a large text file containing words. Given any two words, find the shortest 
         * distance (in terms of number of words) between them in the file. 
         */
        public static int ShortestDistance(string message, string word)
        {
            int distance = 0;

            //remove empty and newlines from initial string
            var msg = message.Split(new char[] { ' ' }, message.Length, StringSplitOptions.RemoveEmptyEntries).
                Where(x => x != "\r\n").ToList();

            //convert List<string> to Dictionary<int, string> using LINQ
            var dict = msg.Select((s, i) => new { s, i }).ToDictionary(x => x.i, x => x.s);

            //search for the given word - ignoring , at the end of the word
            var result = dict.Where(kvp => kvp.Value.ToLower().Replace(',', ' ').Trim() == word).ToArray();

            if (result.Count() < 2)
                return distance;

            List<int> dist = new List<int>();
            for (int i = 0; i < result.Length - 1; i++)
                dist.Add(result.ElementAt(i + 1).Key - result.ElementAt(i).Key);

            return dist.Min();
        }


        //Write a method to count the number of 2s between 0 and n
        public static int Count2s(int n)
        {
            int count = 0;
            for (int i = 0; i <= n; i++)
            {
                var x = i.ToString().ToCharArray();

                foreach (char c in x)
                {
                    if (c == '2')
                        count++;
                }
            }
            return count++;
        }
    }

    public class NumericalMethods
    {
        public static double IntegralSimpson(double a, double b, int n, Func<double, double> f)
        {
            if ((n < 1) || (b < a))
                throw new ArgumentOutOfRangeException();

            double s = f(a) + f(b);
            double h = (b - a) / n;

            for (int i = 1; i < n; i++)
            {
                if ((i % 2) == 0)
                    s += 2 * f(a + i * h);
                else
                    s += 4 * f(a + i * h);
            }

            return h * s / 3;
        }

        public static double IntegralSimpson(double lowerBound, double upperBound, int numberOfSteps, Func<double, double> f, double errorTolerance)
        {
            double currentResult = 0.0;
            double previousResult = double.MaxValue;

            for (int i = 1; i <= numberOfSteps; i++)
            {
                currentResult = IntegralSimpson(lowerBound, upperBound, i, f);

                if (Math.Abs(currentResult - previousResult) < Math.Abs(currentResult* errorTolerance))
                    return currentResult;

                previousResult = currentResult;
            }

            return currentResult;
        }

        public static double IntegralTrapezoidal(double a, double b, int steps, Func<double, double> f)
        {
            double delta = (b - a) / steps;
            double result = 0.5 * (f(a) + f(b));

            for (int i = 1; i < steps; i++)
            {
                a += delta;
                result += f(a);
            }

            return delta * result;
        }

        public static void SolveQuadraticEquation(double a, double b, double c, ref double x0, ref double x1)
        {
            if (a == 0)
                throw new ArgumentOutOfRangeException();

            double d = b*b- 4*a*c;

            if (d < 0)
                throw new ArgumentException();

            double sqrt = Math.Sqrt(d);

            x0 = (-b + sqrt) / (2 * a);
            x1 = (-b - sqrt) / (2 * a);
        }

        public static double NewtonMethod(Func<double, double> f, Func<double, double> g, double x0, int maxNumberOfSteps = int.MaxValue, double tolerance=1E-15)
        {
            // Xn+1 = Xn - [f(Xn)/f'(xn)]

            double nextApproximation = x0;
            double currentSolution = x0;

            for (int i = 0; i < maxNumberOfSteps; i++)
            {
                nextApproximation = currentSolution - (f(currentSolution) / g(currentSolution));

                System.Diagnostics.Trace.WriteLine(i + " -- " + nextApproximation + " sol=" + f(nextApproximation));

                if (Math.Abs(f(nextApproximation)) < Math.Abs(tolerance))
                    return nextApproximation;

                currentSolution = nextApproximation;
            }            
            return nextApproximation;
        }

        public static double BisectionMethod(Func<double,double> f, double a, double b, int maxNumberOfIterations = int.MaxValue, double epsilon = 1E-15)
        {
            if (Math.Sign(f(a)) == Math.Sign(f(b)))
                throw new ArgumentOutOfRangeException();

            if (Math.Abs(f(a)) < epsilon)
                return a;

            if (Math.Abs(f(b)) < epsilon)
                return b;

            double x =0.0;
            for (int i = 0; i < maxNumberOfIterations; i++)
            {
                x = 0.5 * (a + b);

                System.Diagnostics.Trace.WriteLine(string.Format("i={0} x= {1}, f(x)={2}", i, x, f(x)));

                if (Math.Abs(f(x)) < epsilon)
                    return x;

                if (Math.Sign(f(a)) == Math.Sign(f(x)))
                    a = x;
                else
                    b = x;
            }

            return x;
        }

        public static double RegulaFalseMethod(Func<double, double> f, double a, double b, int maxNumberOfIterations = int.MaxValue, double epsilon = 1E-15)
        {
            if (Math.Sign(f(a)) == Math.Sign(f(b)))
                throw new ArgumentOutOfRangeException();

            if (Math.Abs(f(a)) < epsilon)
                return a;

            if (Math.Abs(f(b)) < epsilon)
                return b;

            double x = 0.0;
            for (int i = 0; i < maxNumberOfIterations; i++)
            {
                x = a - f(a) / Slope(f, a, b);

                System.Diagnostics.Trace.WriteLine(string.Format("i={0} x= {1}, f(x)={2}", i, x ,f(x)));

                if (Math.Abs(f(x)) < epsilon)
                    return x;

                if (Math.Sign(f(a)) == Math.Sign(f(x)))
                    a = x;
                else
                    b = x;
            }

            return x;
        }

        public static double Slope(Func<double,double> f, double a, double b)
        {
            if (a == b)
                throw new ArgumentException();

            return (f(b)-f(a))/(b-a);
        }

        public static List<int> FindAllFactors(int n)
        {
            n = Math.Abs(n);

            List<int> factors = new List<int>();

            int flag = n;

            for (int i = 1; i <= flag; i++)
            {
                flag = n / i;

                for (int j = flag; j >= i; j--)
                {
                    if (i * j == n)
                    {
                        if (!factors.Contains(i))
                            factors.Add(i);

                        if (!factors.Contains(j))
                            factors.Add(j);

                        j=0;
                    }
                }
            }

            Utils.PrintList(factors);
            return factors.Select(x => -x).Union(factors).ToList();
        }

        public static List<double> RationalRootsTest(int[] coefficients)
        {
            //The polynomial must have int coeff.

            //coefficients[0] is the constant term
            //coefficients[n-1] is the leading term

            List<double> roots = new List<double>();

            int constantTerm = coefficients[0];
            int leadingTerm = coefficients.Last();

            //find factors
            var p = FindAllFactors(constantTerm);
            var q = FindAllFactors(leadingTerm);

            //find all possible candidates rational roots
            HashSet<double> possibleRoots = new HashSet<double>(); //use HashSet because I don't want duplicates
            foreach (var factorConst in p)
            {
                foreach (var factorLeading in q)
                {
                    possibleRoots.Add((double)factorConst / factorLeading);
                }
            }

            //check which of the possibleRoots are roots of the P(x)
            foreach (var root in possibleRoots)
            {
                double result = 0.0;
                for (int i = 0; i < coefficients.Length; i++)
                {
                    result += coefficients[i] * Math.Pow(root, i);
                }

                if (result == 0)
                {
                    roots.Add(root);
                    Console.WriteLine("root = " + root + " -- " + result);
                }
            }

            return roots;
        }
    }
}
