using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw
{
    class JK
    {
        //convert a list of one type to a list of another by performing some logic on it
        public void ExampleGenericMethods()
        {
            List<int> intList = new List<int>();
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);

            Converter<int, double> converter = TakeSquareRoot; //delegate instance

            var doubleList1 = intList.ConvertAll<double>(converter);
            var doubleList2 = intList.ConvertAll(TakeSquareRoot);
            var doubleList3 = intList.ConvertAll((x) => Math.Sqrt(x));

            Utils.PrintList(intList);
            Utils.PrintList(doubleList1);
            Utils.PrintList(doubleList2);
            Utils.PrintList(doubleList3);
        }

        public static int CompareToDefault<T>(T value) where T : IComparable<T>
        {
            Console.WriteLine("default(T) = " + default(T));
            return value.CompareTo(default(T));
        }

        private static double TakeSquareRoot(int n) { return Math.Sqrt(n); }


        public static void DemonstrateTypeof<X>()
        {
            Console.WriteLine("=======");
            Console.WriteLine(typeof(X));
            Console.WriteLine(typeof(List<>));
            Console.WriteLine(typeof(Dictionary<,>));
            Console.WriteLine(typeof(List<X>));

            Type x = Type.GetType("System.Collections.Generic.List`1[T]");
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;

            Console.WriteLine("name = " + name + " -- price = " + price);
        }

        Product() { Console.WriteLine("---"); }

        public static List<Product> GetSampleProducts()
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("West Side Story1", 9.99m)); //calling the non default constructor

            return new List<Product>
            {
                new Product("West Side Story2", 9.99m), ////calling the non default constructor
                new Product { Name="West Side Story3", Price = 9.99m }, // //calling the default constructor
                new Product { Name="Assassins", Price=14.99m },
                new Product { Name="Frogs", Price=13.99m },
                new Product { Name="Sweeney Todd", Price=10.99m}

            };
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Price);
        }
    }

    public class TypeWithField<T>
    {
        public static string field { get; set; }
        public static void PrintField()
        {
            Console.WriteLine(field + ": " + typeof(T).Name);
        }
    }
}
