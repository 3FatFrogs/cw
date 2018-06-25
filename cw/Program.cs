using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace cw
{
    class Customer
    {
        public double pippo;
        public int Id { get; set; }
        public string  Name { get; set; }

        public Customer(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Customer()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }

        public void PrintId() { Console.WriteLine("Id     = {0}", this.Id); }
        public void PrintName() { Console.WriteLine("Name = {0}", this.Name); }
        public string GetFullName(string firstName, string lastName) { return firstName + " " + lastName;  }

    };

    class Program
    {
        delegate bool MeDelegate(int x); //declare delegate (predicate)
        static bool LessThan5(int x) { return x < 5; }
        static bool LessThan7(int x) { return x < 7; }

        public class GenericList<T>
        {
            public void Add(T input) { }
        }


        public class Person : ICloneable
        {
            object ICloneable.Clone()
            {
                return Clone();
            }

            public Person Clone()
            {
                Person p = new Person();

                return p;
            }
        }


        static void Main(string[] args)
        {
            //ExampleWithReflection();
            int[] pins = { 1, 3, 4, 5, 6, 7 };

            foreach (var i in pins)  //The foreach construct provides an elegant mechanism that greatly simplifies the code you need to write, but it can be exercised only under certain circumstances—you can use foreach only to step through an enumerable collection.
            {
                Console.WriteLine(i);
            }
        }


        public static void Add<T,U>(T key, U value)
        {
            Console.WriteLine(typeof(T).Name);
            Console.WriteLine(typeof(U).Name);
        }

        private static void ExampleWithReflection()
        {
            const string TypeName = "cw.Customer";
            Customer customer = new Customer();// early binding -- create an instance at compile time
            Console.WriteLine(customer.GetFullName("AAA", "BBB")); //early binding

            Assembly executingAssembly = Assembly.GetExecutingAssembly(); //

            Type customerType = executingAssembly.GetType(TypeName); //

            var customerInstance = Activator.CreateInstance(customerType); //create an instance of the obj

            var getFullNameMethod = customerType.GetMethod("GetFullName"); //name of the method we want to run

            string[] parameters = new string[2];  //input of my method

            parameters[0] = "AAA";
            parameters[1] = "BBB";


            string result = (string)getFullNameMethod.Invoke(customerInstance, parameters);

            Console.WriteLine(result);
            return;

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
            var pippo = GetAllValidNumbers(input, (x => x > 7));

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
            if (this.stopMachinery != null)
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
        public void StaplerOff(int sec) { Console.WriteLine(MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name); }
    }

}
