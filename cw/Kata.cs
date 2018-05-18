﻿using System;
using System.Collections.Generic;
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

    public class Sorting: Kata
    {
        public static void BubbleSort(int[] x)
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < x.Length-1; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        swapped = true;
                        Utils.SwapInt(i, i + 1, x);
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
                    Utils.SwapInt(i, posMin, x);
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
                    Utils.SwapInt(j, j - gap, x);
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
                    Utils.SwapInt(lo++, j, A);
            }

            Utils.SwapInt(lo, hi, A);
            return lo;
        }

    }

    public class Exercises: Kata
    {
        /* Write a method to decide if two strings are anagrams or not.*/
        public static bool AreAnagrams(string a, string b)
        {
            //remove spaces and sort
            a = new string(a.ToList().Where(x => x != ' ').Select(x => x).OrderBy(x => x).ToArray());
            b = new string(b.ToList().Where(x => x != ' ').Select(x => x).OrderBy(x => x).ToArray());

            if(a.Length == b.Length)
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
    }
}
