using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace cw
{
    public static class Utils
    {
        public static List<string> ReadFileByLineString(string inputFile)
        {
            List<string> r = new List<string>();
            string lineOfText;

            //check if file exist
            if (!File.Exists(inputFile))
                return r;

            using (System.IO.StreamReader rFile = new System.IO.StreamReader(inputFile, true))
            {
                while ((lineOfText = rFile.ReadLine()) != null)
                {
                    r.Add(lineOfText);
                }
            }
            return r;

        }

        public static bool IsPerfectSquare(long x)
        {
            return (Math.Pow(x, 0.5) % 1 == 0);
        }

        public static bool IsPerfectSquare2(long x)
        {
            if (x < 0)
                return false;

            var squared = Math.Floor(Math.Pow(x, 1 / 2));


            if (squared * squared == x)
                return true;

            return false;
        }

        public static void InitializeIntArrayRandomly(int[] x)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = rand.Next();
            }
        }

        //Newton for sqrt function 
        //todo move this function into NumericalMethods class
        public static double NewtonSqrt(double x, double tol)
        {
            double xn = x / 2;

            double a = 0.0;

            while (true)
            {
                double xn1 = 0.5 * (xn + x / xn);

                if (Math.Abs(xn1 - xn) < tol)
                    return xn1;

                if (++a == double.MaxValue)
                    return 0.0;

                xn = xn1;
            }
        }

        public static string DecimalToBin(long x)
        {
            if (x == 0)
                return "0";

            string result = "";

            while (x >= 1)
            {
                if (x % 2 == 0)
                    result = result + "0";
                else
                    result = result + "1";

                x = x / 2;
            }

            return ReverseStringv1(result);
        }

        public static string DecimalToBin2(long x)
        {
            if (x < 0)
                return "";

            if (x == 0)
                return "0";

            string result = "";

            var numberOfBits = 1 + Math.Floor(d: Math.Log(x, 2));

            for (int i = (int)numberOfBits - 1; i >= 0; i--)
            {
                if ((x & (1 << i)) != 0)
                    result += "1";
                else
                    result += "0";
            }

            return result;

        }

        public static string ReverseStringv1(string input)
        {
            var x = input.ToCharArray();

            Array.Reverse(x);

            return new string(x);
        }

        public static string ReverseStringv2(string input)
        {
            var x = input.ToCharArray();
            int len = x.Length - 1;

            for (int i = 0; i <= len / 2; i++)
            {
                int j = len - i;

                char temp = x[i];
                x[i] = x[j];
                x[j] = temp;
            }

            return new string(x);
        }

        public static List<string> StringCombinations(string s)
        {
            List<string> strList = new List<string>();

            var numberOfCombinations = Math.Pow(2, s.Length);

            string temp;

            for (int i = 0; i < numberOfCombinations; i++)
            {
                temp = null;

                for (int j = 0; j < s.Length; j++)
                {
                    if ((i & (1 << j)) == 0)
                        temp += " ";
                    else
                        temp += s[j];
                }

                strList.Add(temp);
            }

            return strList;
        }

        public static List<string> PrintTruthTable(int n)
        {
            var combination = Math.Pow(2, n);

            List<string> result = new List<string>();

            string temp;

            for (int i = 0; i < combination; i++)
            {
                Console.WriteLine();
                temp = null;

                for (int j = n - 1; j >= 0; j--)
                {
                    if ((i & (1 << j)) == 0)
                        temp += "0";
                    else
                        temp += "1";
                }
                result.Add(temp);
            }

            return result;
        }

        public static long FactorialRecursive(int n)
        {
            if (n < 0)
                throw new Exception("Negative Factorial not implement!!");

            if (n == 0)
                return 1;

            return n * FactorialRecursive(n - 1);
        }

        public static long FactorialIterative(int n)
        {
            if (n < 0)
                throw new Exception("Negative Factorial not implement!!");

            long fact = 1;

            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }

            return fact;
        }

        public static List<string> GetPermutations(String s)
        {
            List<string> permutations = new List<string>();

            if (s == null)
                return null;

            if (s.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }

            char firstChar = s.ElementAt(0);
            string remainder = s.Substring(1, s.Length - 1);
            var words = GetPermutations(remainder);

            foreach (var word in words)
            {
                for (int i = 0; i <= word.Length; i++)
                {
                    string start = word.Substring(0, i);
                    string end = word.Substring(i);
                    permutations.Add(start + firstChar + end);
                }
            }

            return permutations;
        }

        public static void PrintArray<T>(T[] x)
        {
            Console.WriteLine("====================================");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }
            Console.WriteLine();
        }

        public static void PrintList<T>(List<T> x)
        {
            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static List<int> GeneratedList(int startingAt, int count)
        {
            return Enumerable.Range(startingAt, count).ToList();
        }

        public static List<int> GeneratedListRandom(int listLenght)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            List<int> myList = new List<int>();

            for (int i = 0; i < listLenght; i++)
            {
                myList.Add(rand.Next());
            }

            return myList;
        }

        //remove char from string
        public static string Remove(string s, char c)
        {
            var removed = s.ToList().Where(x => x != c).Select(x => x).ToArray();

            return new string(removed);
        }

        public static void SwapElementsInArray<T>(int a, int b, T[] x)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException();

            if (a > x.Length || b > x.Length)
                throw new ArgumentOutOfRangeException();

            if (a != b)
            {
                T temp = x[a];
                x[a] = x[b];
                x[b] = temp;
            }

        }

        //add an extension to the int class
        public static int Negate(this int i)
        {
            return -i;
        }

        //convert List<T> to Dictionary<int, T> using LINQ
        public static Dictionary<int,T> ConvertListToDictionary<T>(List<T> inputList)
        {
            return inputList.Select((value, index) => new { s= value, i=index }).ToDictionary(x => x.i, x => x.s);
        }

        public static void FileWriteLine(string path, string content)
        {
            if (!File.Exists(path))
                File.WriteAllText(path, content);
            else
                File.AppendAllText(path, content + Environment.NewLine);
        }
        
    }
}
