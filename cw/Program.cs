using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace cw
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

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
        public string GetFullName(string firstName, string lastName) { return firstName + " " + lastName; }

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
            int[,] x = new int[9, 9];

            SetInitialValues(x);
            //SetInitialValues_1(x);

            PrintSudokuMatrix(x);
            bool flag = true;
            while (flag)
            {
                bool updated = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        int numberToAdd = 0;
                        int counter = 0;
                        for (int k = 1; k < 10; k++)
                        {
                            bool correct = CanIadd(x, k, i, j);

                            if (correct)
                            {
                                counter++;
                                numberToAdd = k;
                            }

                            if (counter > 1)
                                k = 10;
                        }

                        if (counter == 1)
                        {
                            updated = true;
                            x[i, j] = numberToAdd;
                            PrintSudokuMatrix(x);
                            Console.WriteLine();
                            Console.WriteLine("--- i,j = " + (i + 1) + "," + (j + 1) + " => " + numberToAdd);
                            Console.WriteLine("Remain " + CountZero(x) + " cells");
                        }
                    }
                }

                flag = updated;

            }
        }

        private static int CountZero(int[,] x)
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (x[i, j] == 0)
                        counter++;
                }
            }

            return counter;
        }

        private static void PrintSudokuMatrix(int[,] x)
        {
            Console.WriteLine("========================");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (x[i, j] == 0)
                        Console.Write("x" + " ");
                    else
                        Console.Write(x[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        private static void SetInitialValues(int[,] x)
        {
            x[0, 0] = 4;
            x[0, 1] = 8;
            x[0, 2] = 0;
            x[0, 3] = 6;
            x[0, 4] = 0;
            x[0, 5] = 2;
            x[0, 6] = 0;
            x[0, 7] = 0;
            x[0, 8] = 0;

            x[1, 0] = 0;
            x[1, 1] = 2;
            x[1, 2] = 7;
            x[1, 3] = 0;
            x[1, 4] = 0;
            x[1, 5] = 0;
            x[1, 6] = 1;
            x[1, 7] = 0;
            x[1, 8] = 0;

            x[2, 0] = 3;
            x[2, 1] = 0;
            x[2, 2] = 0;
            x[2, 3] = 1;
            x[2, 4] = 0;
            x[2, 5] = 0;
            x[2, 6] = 0;
            x[2, 7] = 0;
            x[2, 8] = 8;

            x[3, 0] = 1;
            x[3, 1] = 6;
            x[3, 2] = 2;
            x[3, 3] = 4;
            x[3, 4] = 9;
            x[3, 5] = 0;
            x[3, 6] = 0;
            x[3, 7] = 8;
            x[3, 8] = 0;

            x[4, 0] = 0;
            x[4, 1] = 0;
            x[4, 2] = 0;
            x[4, 3] = 0;
            x[4, 4] = 0;
            x[4, 5] = 0;
            x[4, 6] = 0;
            x[4, 7] = 0;
            x[4, 8] = 0;

            x[5, 0] = 0;
            x[5, 1] = 4;
            x[5, 2] = 0;
            x[5, 3] = 0;
            x[5, 4] = 1;
            x[5, 5] = 7;
            x[5, 6] = 6;
            x[5, 7] = 3;
            x[5, 8] = 2;

            x[6, 0] = 6;
            x[6, 1] = 0;
            x[6, 2] = 0;
            x[6, 3] = 0;
            x[6, 4] = 0;
            x[6, 5] = 1;
            x[6, 6] = 0;
            x[6, 7] = 0;
            x[6, 8] = 5;


            x[7, 0] = 0;
            x[7, 1] = 0;
            x[7, 2] = 9;
            x[7, 3] = 0;
            x[7, 4] = 0;
            x[7, 5] = 0;
            x[7, 6] = 2;
            x[7, 7] = 4;
            x[7, 8] = 0;

            x[8, 0] = 0;
            x[8, 1] = 0;
            x[8, 2] = 0;
            x[8, 3] = 9;
            x[8, 4] = 0;
            x[8, 5] = 4;
            x[8, 6] = 0;
            x[8, 7] = 7;
            x[8, 8] = 1;
        }
        private static void SetInitialValues_1(int[,] x)
        {
            x[0, 0] = 7;
            x[0, 1] = 4;
            x[0, 2] = 2;
            x[0, 3] = 0;
            x[0, 4] = 3;
            x[0, 5] = 8;
            x[0, 6] = 0;
            x[0, 7] = 0;
            x[0, 8] = 1;

            x[1, 0] = 0;
            x[1, 1] = 3;
            x[1, 2] = 0;
            x[1, 3] = 0;
            x[1, 4] = 0;
            x[1, 5] = 0;
            x[1, 6] = 4;
            x[1, 7] = 0;
            x[1, 8] = 6;

            x[2, 0] = 5;
            x[2, 1] = 0;
            x[2, 2] = 0;
            x[2, 3] = 0;
            x[2, 4] = 0;
            x[2, 5] = 0;
            x[2, 6] = 8;
            x[2, 7] = 0;
            x[2, 8] = 0;

            x[3, 0] = 2;
            x[3, 1] = 8;
            x[3, 2] = 0;
            x[3, 3] = 7;
            x[3, 4] = 6;
            x[3, 5] = 0;
            x[3, 6] = 0;
            x[3, 7] = 0;
            x[3, 8] = 0;

            x[4, 0] = 0;
            x[4, 1] = 6;
            x[4, 2] = 0;
            x[4, 3] = 8;
            x[4, 4] = 0;
            x[4, 5] = 9;
            x[4, 6] = 0;
            x[4, 7] = 5;
            x[4, 8] = 0;

            x[5, 0] = 0;
            x[5, 1] = 0;
            x[5, 2] = 0;
            x[5, 3] = 0;
            x[5, 4] = 2;
            x[5, 5] = 3;
            x[5, 6] = 0;
            x[5, 7] = 6;
            x[5, 8] = 8;

            x[6, 0] = 0;
            x[6, 1] = 0;
            x[6, 2] = 4;
            x[6, 3] = 0;
            x[6, 4] = 0;
            x[6, 5] = 0;
            x[6, 6] = 0;
            x[6, 7] = 0;
            x[6, 8] = 2;


            x[7, 0] = 6;
            x[7, 1] = 0;
            x[7, 2] = 7;
            x[7, 3] = 0;
            x[7, 4] = 0;
            x[7, 5] = 0;
            x[7, 6] = 0;
            x[7, 7] = 3;
            x[7, 8] = 0;

            x[8, 0] = 1;
            x[8, 1] = 0;
            x[8, 2] = 0;
            x[8, 3] = 4;
            x[8, 4] = 9;
            x[8, 5] = 0;
            x[8, 6] = 7;
            x[8, 7] = 8;
            x[8, 8] = 5;
        }

        public static bool CanIadd(int[,] sud, int numberToAdd, int row, int col)
        {
            if (numberToAdd < 1 || numberToAdd > 9)
                return false;

            if (sud[row, col] != 0)
                return false;

            var verticalSlice = GetVerticalSlice(col, sud);
            var horizontalSlice = GetHorizontalSlice(row, sud);
            var subSquare = GetSubSquare(FindIndexSquare(row, col), sud);

            //Utils.PrintArray(verticalSlice,false);
            //Utils.PrintArray(horizontalSlice);
            //Utils.PrintArray(subSquare);

            if (verticalSlice.Contains(numberToAdd) || horizontalSlice.Contains(numberToAdd) || subSquare.Contains(numberToAdd))
                return false;

            return true;
        }

        public static int FindIndexSquare(int i, int j)
        {
            if (i < 3)
            {
                if (j < 3) return 0;
                if (j < 6) return 1;
                return 2;
            }
            else if (i < 6)
            {
                if (j < 3) return 3;
                if (j < 6) return 4;
                return 5;
            }
            else
            {
                if (j < 3) return 6;
                if (j < 6) return 7;
                return 8;
            }
        }

        public static int[] GetSubSquare(int index, int[,] square)
        {
            int[] subSquare = new int[9];

            if (index == 0)
            {
                subSquare[0] = square[0, 0];
                subSquare[1] = square[0, 1];
                subSquare[2] = square[0, 2];
                subSquare[3] = square[1, 0];
                subSquare[4] = square[1, 1];
                subSquare[5] = square[1, 2];
                subSquare[6] = square[2, 0];
                subSquare[7] = square[2, 1];
                subSquare[8] = square[2, 2];
            }
            else if (index == 1)
            {
                subSquare[0] = square[0, 3];
                subSquare[1] = square[0, 4];
                subSquare[2] = square[0, 5];
                subSquare[3] = square[1, 3];
                subSquare[4] = square[1, 4];
                subSquare[5] = square[1, 5];
                subSquare[6] = square[2, 3];
                subSquare[7] = square[2, 4];
                subSquare[8] = square[2, 5];
            }
            else if (index == 2)
            {
                subSquare[0] = square[0, 6];
                subSquare[1] = square[0, 7];
                subSquare[2] = square[0, 8];
                subSquare[3] = square[1, 6];
                subSquare[4] = square[1, 7];
                subSquare[5] = square[1, 8];
                subSquare[6] = square[2, 6];
                subSquare[7] = square[2, 7];
                subSquare[8] = square[2, 8];
            }
            else if (index == 3)
            {
                subSquare[0] = square[3, 0];
                subSquare[1] = square[3, 1];
                subSquare[2] = square[3, 2];
                subSquare[3] = square[4, 0];
                subSquare[4] = square[4, 1];
                subSquare[5] = square[4, 2];
                subSquare[6] = square[5, 0];
                subSquare[7] = square[5, 1];
                subSquare[8] = square[5, 2];
            }
            else if (index == 4)
            {
                subSquare[0] = square[3, 3];
                subSquare[1] = square[3, 4];
                subSquare[2] = square[3, 5];
                subSquare[3] = square[4, 3];
                subSquare[4] = square[4, 4];
                subSquare[5] = square[4, 5];
                subSquare[6] = square[5, 3];
                subSquare[7] = square[5, 4];
                subSquare[8] = square[5, 5];
            }
            else if (index == 5)
            {
                subSquare[0] = square[3, 6];
                subSquare[1] = square[3, 7];
                subSquare[2] = square[3, 8];
                subSquare[3] = square[4, 6];
                subSquare[4] = square[4, 7];
                subSquare[5] = square[4, 8];
                subSquare[6] = square[5, 6];
                subSquare[7] = square[5, 7];
                subSquare[8] = square[5, 8];
            }
            else if (index == 6)
            {
                subSquare[0] = square[6, 0];
                subSquare[1] = square[6, 1];
                subSquare[2] = square[6, 2];
                subSquare[3] = square[7, 0];
                subSquare[4] = square[7, 1];
                subSquare[5] = square[7, 2];
                subSquare[6] = square[8, 0];
                subSquare[7] = square[8, 1];
                subSquare[8] = square[8, 2];
            }

            else if (index == 7)
            {
                subSquare[0] = square[6, 3];
                subSquare[1] = square[6, 4];
                subSquare[2] = square[6, 5];
                subSquare[3] = square[7, 3];
                subSquare[4] = square[7, 4];
                subSquare[5] = square[7, 5];
                subSquare[6] = square[8, 3];
                subSquare[7] = square[8, 4];
                subSquare[8] = square[8, 5];
            }

            else if (index == 8)
            {
                subSquare[0] = square[6, 6];
                subSquare[1] = square[6, 7];
                subSquare[2] = square[6, 8];
                subSquare[3] = square[7, 6];
                subSquare[4] = square[7, 7];
                subSquare[5] = square[7, 8];
                subSquare[6] = square[8, 6];
                subSquare[7] = square[8, 7];
                subSquare[8] = square[8, 8];
            }

            return subSquare;
        }

        public static int[] GetHorizontalSlice(int iRow, int[,] square)
        {
            int[] slice = new int[9];

            for (int i = 0; i < 9; i++)
            {
                slice[i] = square[iRow, i];
            }

            return slice;
        }
        

        public static int[] GetVerticalSlice(int iCol, int[,] square)
        {
            int[] slice = new int[9];

            for (int i = 0; i < 9; i++)
            {
                slice[i] = square[i, iCol];
            }

            return slice;
        }

        public static void Add<T, U>(T key, U value)
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
