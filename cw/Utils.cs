using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

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

            var squared = Math.Floor(Math.Pow(x,1/2));

            
            if (squared * squared == x)
                return true;

            return false;
        }

        public static double NewtonSqrt(double x, double tol)
        {
            double xn = x / 2;

            double a = 0.0;

            while (true)
            {
                double xn1 = 0.5* (xn + x/xn);

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
            if(x<0)
                return "";

            if (x == 0)
                return "0";

            string result = "";

            var numberOfBits = 1 + Math.Floor(d: Math.Log(x, 2));

            for (int i = (int)numberOfBits-1; i >=0; i--)
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
            int len = x.Length-1;

            for (int i = 0; i <= len/2; i++)
            {
                int j = len - i;

                char temp = x[i];
                x[i] = x[j];
                x[j] = temp;
            }

            return new string(x);
        }

        public static List<string> StringPermutations(string s)
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
    }
}
