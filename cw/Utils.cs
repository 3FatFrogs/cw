using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
