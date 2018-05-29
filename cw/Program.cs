using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;
using System.Reflection;

namespace cw
{
    class Program
    {
        delegate bool MeDelegate(int x); //declare delegate (predicate)
        static bool LessThan5(int x) { return x < 5; }
        static bool LessThan7(int x) { return x < 7; }

        static void Main(string[] args)
        {
            //ExampleWithDelegate();
            ExampleDelegatemachinery();
        }

        private static void ExampleDelegatemachinery()
        {
            Console.WriteLine("===============================");
            FoldingMachine f = new FoldingMachine();
            WeldingMachine w = new WeldingMachine();
            PaintingMachine p = new PaintingMachine();
            StaplerMachiner s = new StaplerMachiner();
            Controller c = new Controller(f, w, p, s);
            c.StopAllMachines();

            Console.WriteLine("===============================");
            GoodController g = new GoodController();
            g.AddStopMachinery(f.StopFolding);
            g.AddStopMachinery(w.FinishWelding);
            g.AddStopMachinery(w.FinishWelding);
            g.AddStopMachinery(w.FinishWelding);
            g.AddStopMachinery(w.FinishWelding);
            g.AddStopMachinery(p.PaintOff);
            g.AddStopMachinery(() => s.StaplerOff(0));  // or use anonymous method as this:   g.AddStopMachinery(delegate { s.StaplerOff(0); });
            g.ShutDown();

            TemperatureMonitor t = new TemperatureMonitor();
            t.MachineOverheating += w.FinishWelding; //Subscribing to an event
            t.MachineOverheating += p.PaintOff;
            t.Notify(); //raise event

            //g.Notify();

            Console.WriteLine("===============================");
        }

        private static void ExampleWithDelegate()
        {
            var input = new[] { 3, 4, 3, 2, 6, 7, 8, 4, 3, 5, 11, 31, 4, 17 };

            var result1 = GetAllNumbersLessThan5(input);
            var result2 = GetAllNumbersLessThan7(input);
            var result3 = GetAllValidNumbers(input, LessThan5);

            var pippo = GetAllValidNumbers(input, (x=>x>7));

            Utils.PrintArray(result1.ToArray());
            Utils.PrintArray(result2.ToArray());
            Utils.PrintArray(result3.ToArray());
            Utils.PrintArray(pippo.ToArray());
        }


        static IEnumerable<int> GetAllValidNumbers(IEnumerable<int> numbers, MeDelegate gauntlet)
        {
            foreach (var number in numbers)
            {
                if (gauntlet(number))
                    yield return number;
            }
        }

        static IEnumerable<int> GetAllNumbersLessThan5(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number < 5)
                    yield return number;
            }
        }

        static IEnumerable<int> GetAllNumbersLessThan7(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number < 7)
                    yield return number;
            }
        }

        static void Foo() { Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name); }

        public static List<string> Bar(string s)
        {
            List<string> permutations = new List<string>();

            if (s == null)
                return null;

            if (s.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }
            return permutations;
        }

        public static string AddSpace(string str)
        {
            var x = str.ToCharArray();
            var z = str.ToList();


            var pippo = z.ToString();

            return "dfqad";

            //return new string();
        }

        public static string ConvertListToString<T>(List<T> l)
        {
            return string.Join("", l.ToArray());
        }

        public static List<string> Foo2(string str, char c = 'X')
        {
            var y = str.ToCharArray();
            List<string> result = new List<string>();

            for (int i = 0; i < str.Length + 1; i++)
            {
                char[] x = new char[str.Length + 1];
                x[i] = c;
                int position = 0;
                for (int j = 0; j < str.Length + 1; j++)
                {
                    if (i != j)
                        x[j] = y[position++];
                }

                result.Add(new string(x));
            }

            return result;
        }
    }

    class TemperatureMonitor
    {
        public delegate void TestMyStopMachineryDelegate(); //declare delegate
        public event TestMyStopMachineryDelegate MachineOverheating; // event

        public void Notify()
        {
            this.MachineOverheating?.Invoke();
        }
    }

    class GoodController
    {
        public delegate void stopMachineryDelegate(); //declare delegate
        stopMachineryDelegate stopMachinery;  // create an instance of the delegate
        public event stopMachineryDelegate MachineOverheating;  //declare event

        public void ShutDown()
        {
            this.stopMachinery(); //invoke
        }

        public void AddStopMachinery(stopMachineryDelegate machineToStop)
        {
            if (stopMachinery != null)
            {
                var listDelegated = stopMachinery.GetInvocationList().Select(x => x.Method).Select(x => x.Name).ToList();

                //I don't want to add duplicates
                if (!listDelegated.Contains(machineToStop.Method.Name))
                    this.stopMachinery += machineToStop;  //add(subscribe) methods to delegate
            }
            else
            {
                this.stopMachinery += machineToStop;  //add(subscribe) methods to delegate
            }
        }

        public void RemoveStopMachinery(stopMachineryDelegate machine)
        {
            if(this.stopMachinery!=null)
                this.stopMachinery -= machine;
        }
    }

    class Controller
    {
        private FoldingMachine folder;
        private WeldingMachine welder;
        private PaintingMachine painter;
        private StaplerMachiner stapler;

        public void StopAllMachines()
        {
            folder.StopFolding();
            welder.FinishWelding();
            painter.PaintOff();
            stapler.StaplerOff(0);
        }

        public Controller(FoldingMachine folder, WeldingMachine welder, PaintingMachine painter, StaplerMachiner s)
        {
            this.folder = folder;
            this.welder = welder;
            this.painter = painter;
            this.stapler = s;
            Console.WriteLine(MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
        }
    }

    class FoldingMachine
    {
        public void StopFolding() { Console.WriteLine(MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name); }
    }

    class WeldingMachine
    {
        public void FinishWelding() { Console.WriteLine(MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name); }
    }

    class PaintingMachine
    {
        public void PaintOff() { Console.WriteLine(MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name); }
    }

    class StaplerMachiner
    {
        public void StaplerOff (int sec) { Console.WriteLine(MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name); }
    }






















    struct Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Processor
    {
        public Processor()
        {
            Console.WriteLine("*** CTOR ***");
        }

        public void PerformCalculation()
        {
            string nameMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
            var className = this.GetType().FullName;
            Console.WriteLine("*** " + className + " - " + nameMethod);
        }
    }

    class Polygon
    {
        public int NumSide { get; set; }
    }

    class Triangle
    {
        private int sideLength1 = 10;
        private int sideLength2 = 10;
        private int sideLength3 = 10;

        public int SideLength1
        {
            set { this.sideLength1 = value; }
        }

        public int SideLength2
        {
            set { this.sideLength2 = value; }
        }

        public int SideLength3
        {
            get { return this.sideLength3; }
            set { this.sideLength3 = value; }
        }

        public int SideLength { get; set; }

        public void Print()
        {
            Console.WriteLine(sideLength1);
            Console.WriteLine(sideLength2);
            Console.WriteLine(sideLength3);
        }

    }

    class FooDisposable : IDisposable
    {
        private bool alreadyDisposed = false;
        public double[] managedResources;

        public void Hello()
        {
            Console.WriteLine("Hello");
        }

        public FooDisposable(int size)
        {
            managedResources = new double[size];
            Console.WriteLine("*** CTOR Foo ");
        }

        ~FooDisposable()
        {
            Console.WriteLine("*** DTOR Foo ");
            DisposeAll(false);
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(true) / 1048576);
        }

        public void Dispose()
        {
            Console.WriteLine("*** Dispose ");
            DisposeAll(true);
            GC.SuppressFinalize(this); //This method stops the garbage collector from calling the destructor on this object, because the object has already been finalized.
        }

        public virtual void DisposeAll(bool disposing)
        {
            if (!alreadyDisposed)
            {
                if (disposing)
                {
                    managedResources = null;
                }

                //release unmanaged resource here
                this.alreadyDisposed = true;
            }
        }
    }

    class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("CTOR - BaseClass");
        }

        ~BaseClass()
        {
            Console.WriteLine("DTOR - BaseClass");
        }

        public BaseClass(string str)
        {
            Console.WriteLine("CTOR - BaseClass " + str);
        }

        public int Addition(params int[] x)
        {
            int sum = 0;

            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i];
            }
            return sum;
        }

        public virtual void Foo()
        {
            Console.WriteLine("Foo - BaseClass");
        }

        protected virtual void Bar()
        {
            Console.WriteLine("Bar - BaseClass");
        }
    }

    class Derived : BaseClass
    {
        public Derived()
        {
            Console.WriteLine("CTOR - Derived");
        }

        public override void Foo()
        {
            Console.WriteLine("Foo - Derived");
        }

    }

    class Derived2 : Derived
    {
        public Derived2()
        {
            Console.WriteLine("CTOR - Derived2");
        }

        public override void Foo()
        {
            Console.WriteLine("Foo - Derived2");
        }
    }

    interface ITest1
    {
        string Name { get; set; }
        void SampleTest();
        int ReturnMe(int j);
    }

    interface ITest2
    {
        void SampleTest();
        int Return(int j);
    }

    class Pippo : ITest1, ITest2
    {
        void ITest1.SampleTest()
        {
            Console.WriteLine("SampleTest");
        }

        void ITest2.SampleTest()
        {
            Console.WriteLine("SampleTest");
        }

        public int ReturnMe(int j)
        {
            return 5;
        }

        public int Return(int j)
        {
            return 3;
        }

        public string Name { get; set; }

    }
}
