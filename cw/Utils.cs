using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

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
    }
}
