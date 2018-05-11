using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace cw
{
    class Program
    {
        static void Main(string[] args)
        {
            string strMain = "main";

            DoSomething(strMain);
            Console.Write(strMain); // What gets printed?

            List<int> x = new List<int>();
            x.Add(3424);
            UpdateList(x);

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
        }

        public static void DoSomething(string strLocal)
        {
            strLocal = "local";
        }

        public static void UpdateList(List<int> x)
        {
            x.Add(22);
        }


    }
}
