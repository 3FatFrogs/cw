using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw
{
    public class Sudo
    {

        public static int[,] SolveSud(int[,] x)
        {
            //first try without aby guess
            bool solved = Solution3(x);


            //try to guess one cell
            if (!solved)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (x[i, j] == 0)
                        {
                            for (int k = 1; k < 10; k++)
                            {
                                if (CanIadd2(x, k, i, j))
                                {
                                    int[,] temp = DeepCopyGrid(x);
                                    temp[i, j] = k;

                                    try
                                    {
                                        if (Solution3(temp))
                                            return temp;
                                    }
                                    catch (Exception e)
                                    {
                                        if (e.Message.Equals("Value already stored"))
                                            continue; //we don't care now because we are using on a potential grid solution
                                    }

                                }
                            }
                        }
                        
                    }
                }
            }


            //try to guess two cell
            if (!solved)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (x[i, j] == 0)
                        {
                            for (int k = 1; k < 10; k++)
                            {
                                if (CanIadd2(x, k, i, j))
                                {
                                    int[,] tempFullGrid = DeepCopyGrid(x);
                                    tempFullGrid[i, j] = k;  //first guess

                                    //second guess
                                    for (int ii = 0; ii < 9; ii++)
                                    {
                                        for (int jj = 0; jj < 9; jj++)
                                        {
                                            if (tempFullGrid[ii, jj] == 0)
                                            {
                                                for (int kk = 1; kk < 10; kk++)
                                                {
                                                    if (CanIadd2(tempFullGrid, kk, ii, jj))
                                                    {
                                                        tempFullGrid[ii, jj] = kk;  //second guess

                                                        try
                                                        {
                                                            if (Solution3(tempFullGrid))
                                                            {
                                                                return tempFullGrid;
                                                            }
                                                            
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            if (e.Message.Equals("Value already stored"))
                                                                continue; //we don't care now because we are using on a potential grid solution
                                                        }
                                                        Console.WriteLine("===before " + CountZero(tempFullGrid));
                                                        tempFullGrid = DeepCopyGrid(x);  //remove latest changes done by Solution3
                                                        Console.WriteLine("===after  " + CountZero(tempFullGrid));
                                                        tempFullGrid[i, j] = k;  // put back first guess
                                                        //tempFullGrid[ii, jj] = 0;  //remove second guess

                                                    }
                                                }
                                            }
                                        }
                                    }














                                }
                            }
                        }

                    }
                }
            }

            return x;
        }

        //function that search in the full grid for one zero and returns one possible solution for the cell with zero - ie returns the coordinate and the possible solution
        //the search does not start from 0,0 but it starts from the input row and col
        private static Tuple<int,int,int> GetPossibleSolution(int row, int col, int[,] grid)
        {
            //Tuple<int, int, int>  row,col,value

            for (int ii = 0; ii < 9; ii++)
            {
                for (int jj = 0; jj < 9; jj++)
                {
                    if (grid[ii, jj] == 0)
                    {
                        for (int kk = 1; kk < 10; kk++)
                        {
                            if (CanIadd2(grid, kk, ii, jj))
                            {
                                return Tuple.Create(ii, jj, kk);
                            }
                        }
                    }
                }
            }

            return Tuple.Create(row, col, 0); //WeakReference should never arrive here



        }

        private static bool Solution3(int[,] x)
        {
            bool flag = true;
            while (flag)
            {
                bool updated = false;
                for (int i = 0; i < 9; i++)
                {
                    var missigValue = GetTheMissing(GetHorizontalSlice(i, x));
                    if (missigValue.Item1 != -1)
                        AddElementToGrid(missigValue.Item2, i, missigValue.Item1, x);

                    for (int j = 0; j < 9; j++)
                    {
                        missigValue = GetTheMissing(GetVerticalSlice(j, x));
                        if (missigValue.Item1 != -1)
                            AddElementToGrid(missigValue.Item2, missigValue.Item1, j, x);

                        List<int> numberToAdd = new List<int>();

                        for (int k = 1; k < 10; k++)
                        {
                            bool correct = CanIadd2(x, k, i, j);
                            if (correct)
                            {
                                if (i == 8 && j == 2) ;
                                numberToAdd.Add(k);
                            }
                        }

                        if (numberToAdd.Count == 1)
                        {
                            updated = true;
                            AddElementToGrid(numberToAdd.ElementAt(0), i, j, x);
                            //PrintInfoDebug(x, i, j);
                        }
                        else if (numberToAdd.Count > 1)
                        {
                            if (i == 8 && j == 2) ;

                            var indexHoriz = GetVicini(i);
                            var sliceHor1 = GetHorizontalSlice(indexHoriz.Item1, x);
                            var sliceHor2 = GetHorizontalSlice(indexHoriz.Item2, x);
                            var sliceHorizontalCurrent = GetHorizontalSlice(i, x);

                            var indexVertical = GetVicini(j);
                            var sliceVer1 = GetVerticalSlice(indexVertical.Item1, x);
                            var sliceVer2 = GetVerticalSlice(indexVertical.Item2, x);

                            var sliceVerticalCurrent = GetVerticalSlice(j, x);

                            foreach (int value in numberToAdd)
                            {
                                if (((sliceHor1.Contains(value)) && (sliceHor2.Contains(value)) && (GetNumberOfZeros(j, sliceHorizontalCurrent) == 1)) || ((sliceVer1.Contains(value)) && (sliceVer2.Contains(value)) && GetNumberOfZeros(i, sliceVerticalCurrent) == 1))
                                {
                                    //Console.WriteLine(value);
                                    updated = true;
                                    AddElementToGrid(value, i, j, x);
                                    continue;
                                }

                                if ((sliceHor1.Contains(value)) && (sliceHor2.Contains(value)) && (sliceVer1.Contains(value)) && (sliceVer2.Contains(value)))
                                {
                                    updated = true;
                                    AddElementToGrid(value, i, j, x);
                                    continue;
                                }
                            }
                        }
                    }
                }
                flag = updated;
            }

            if (CountZero(x) == 0)
                return true;
            else
                return false;

        }

        private static void PrintPossibleSolution(int i, int j, List<int> numberToAdd, Tuple<int, int> indexHoriz, int[] sliceHorizontal1, int[] sliceHorizontal2, Tuple<int, int> indexVertical, int[] sliceVertical1, int[] sliceVertical2)
        {
            Console.WriteLine(string.Format("Possible solutions for {0},{1} is {2} {3}", i, j, numberToAdd.ElementAt(0), numberToAdd.ElementAt(1)));
            Console.Write("H " + indexHoriz.Item1 + "->"); Utils.PrintArray(sliceHorizontal1, false);
            Console.Write("H " + indexHoriz.Item2 + "->"); Utils.PrintArray(sliceHorizontal2, false);
            Console.Write("V " + indexVertical.Item1 + "->"); Utils.PrintArray(sliceVertical1, false);
            Console.Write("V " + indexVertical.Item2 + "->"); Utils.PrintArray(sliceVertical2, false);
        }

        public static void AddElementToGrid(int value, int row, int col, int[,] grid)
        {
            if (row == 8 && col == 2)
            {
                ;
            }
            var v = GetVerticalSlice(col, grid);
            var h = GetHorizontalSlice(row, grid);
            var s = GetSubSquare(FindIndexSquare(row, col), grid);

            if (v.Contains(value) || h.Contains(value) || s.Contains(value))
            {
                Console.WriteLine(row + "," + col + "  try add " + value);
                throw new Exception("Value already stored");
            }
            grid[row, col] = value;
            PrintSudokuMatrix(grid, row, col, value);

        }

        private static Tuple<int, int> GetTheMissing(int[] slice) //in case we have 8 values already filled, returns the index and the value
        {
            Tuple<int, int> t = Tuple.Create(-1, 0);
            if (slice.Count(x => x == 0) == 1)
            {
                int result = 45 - slice.Sum(x => x);
                var index = Array.FindIndex(slice, w => w == 0);

                if (result > 9 || result < 0)
                    throw new Exception("Something wrong");

                t = Tuple.Create(index, result);
            }

            return t;
        }

        private static void PrintInfoDebug(int[,] x, int i, int j)
        {
            //PrintSudokuMatrix(x);
            Console.WriteLine();
            //Console.WriteLine("--- i,j = " + (i + 1) + "," + (j + 1) + " => " + x[i, j]);
            Console.WriteLine("Remain " + CountZero(x) + " cells");
        }

        private static Tuple<int, int> GetVicini(int i)
        {
            int[] x = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            if (i == 0) return Tuple.Create(1, 2);
            if (i == 1) return Tuple.Create(0, 2);
            if (i == 2) return Tuple.Create(0, 1);

            if (i == 3) return Tuple.Create(4, 5);
            if (i == 4) return Tuple.Create(3, 5);
            if (i == 5) return Tuple.Create(3, 4);

            if (i == 6) return Tuple.Create(7, 8);
            if (i == 7) return Tuple.Create(6, 8);
            if (i == 8) return Tuple.Create(6, 7);

            return Tuple.Create(-1, -1);
        }

        //return the number of zero within a slized subsquare
        private static int GetNumberOfZeros(int i, int[] slice)
        {
            int zeros = 0;
            if (i < 3)
            {
                zeros = slice.Where((x, index) => index < 3).Count(x => x == 0);
            }
            else if (i < 6)
            {
                zeros = slice.Where((x, index) => index >= 3 && index < 6).Count(x => x == 0);
            }
            else
            {
                zeros = slice.Where((x, index) => index >= 6).Count(x => x == 0);
            }
            if (zeros == 1)
            {
                ;
            }

            return zeros;
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

        public static void PrintSudokuMatrixConsole(int[,] x)
        {
            Console.WriteLine(" ========================");
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

            Console.WriteLine("Remain " + CountZero(x) + " cells");
        }

        public static void PrintSudokuMatrix(int[,] x, int row = -1, int col = -1, int value = -1, bool debug = false)
        {
            string path = @"C:\Users\Emanuele\Desktop\test.txt";

            string str = "";

            if (debug == true)
                str += Environment.NewLine + "**** DEBUG - FAKE GRID *****" + Environment.NewLine;

            if (row != -1)
                str += "Adding " + row + "," + col + "  value:" + value + Environment.NewLine;


            //header
            str += "\t\t";
            for (int i = 0; i < 9; i++)
            {
                str += i + "\t";
            }
            str += Environment.NewLine;
            for (int i = 0; i < 9; i++)
            {
                str += i + "\t{" + "\t";
                for (int j = 0; j < 9; j++)
                {
                    if (x[i, j] == 0)
                        str += "0," + "\t";
                    else
                        str += x[i, j] + "," + "\t";
                }
                str += "},";
                str += Environment.NewLine;
            }
            Utils.FileWriteLine(path, str);
            Utils.FileWriteLine(path, "Remain " + CountZero(x) + " cells");

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

            if (verticalSlice.Contains(numberToAdd) || horizontalSlice.Contains(numberToAdd) || subSquare.Contains(numberToAdd))
                return false;

            return true;
        }

        public static bool CanIadd2(int[,] grid, int numberToAdd, int row, int col)
        {
            //copy grid
            int[,] tempFullGrid = DeepCopyGrid(grid);

            int indexSmallGrid = FindIndexSquare(row, col);

            List<int> smallGridToBeChecked = SelectSubGrid(indexSmallGrid);

            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (var k in smallGridToBeChecked)
            {
                var result = FreeRow(k, tempFullGrid);

                if (result.Item1)
                {
                    if (indexSmallGrid == 0)
                    {
                        if ((k == 1 || k == 2) && result.Item3 == 'H')
                            FillTempGrid(tempFullGrid, a, k, result);

                        if ((k == 3 || k == 6) && result.Item3 == 'V')
                            FillTempGrid(tempFullGrid, a, k, result);
                    }

                    else if (indexSmallGrid == 3)
                    {
                        if ((k == 4 || k == 5) && result.Item3 == 'H')
                            FillTempGrid(tempFullGrid, a, k, result);

                        if ((k == 0 || k == 6) && result.Item3 == 'V')
                            FillTempGrid(tempFullGrid, a, k, result);
                    }

                    else if (indexSmallGrid == 6) //fill 78 rows and 03 col
                    {
                        if ((k == 7 || k == 8) && result.Item3 == 'H')
                            FillTempGrid(tempFullGrid, a, k, result);

                        if ((k == 0 || k == 3) && result.Item3 == 'V')
                            FillTempGrid(tempFullGrid, a, k, result);
                    }

                    else if (indexSmallGrid == 1)
                    {
                        if ((k == 0 || k == 2) && result.Item3 == 'H')
                            FillTempGrid(tempFullGrid, a, k, result);

                        if ((k == 4 || k == 7) && result.Item3 == 'V')
                            FillTempGrid(tempFullGrid, a, k, result);
                    }

                    else if (indexSmallGrid == 4)
                    {
                        if ((k == 3 || k == 5) && result.Item3 == 'H')
                            FillTempGrid(tempFullGrid, a, k, result);

                        if ((k == 1 || k == 7) && result.Item3 == 'V')
                            FillTempGrid(tempFullGrid, a, k, result);
                    }

                    else if (indexSmallGrid == 7) //fill 78 rows and 03 col
                    {
                        if ((k == 6 || k == 8) && result.Item3 == 'H')
                            FillTempGrid(tempFullGrid, a, k, result);

                        if ((k == 1 || k == 4) && result.Item3 == 'V')
                            FillTempGrid(tempFullGrid, a, k, result);
                    }

                    else if (indexSmallGrid == 2)
                    {
                        if ((k == 0 || k == 1) && result.Item3 == 'H')
                            FillTempGrid(tempFullGrid, a, k, result);

                        if ((k == 5 || k == 8) && result.Item3 == 'V')
                            FillTempGrid(tempFullGrid, a, k, result);
                    }

                    else if (indexSmallGrid == 5)
                    {
                        if ((k == 3 || k == 4) && result.Item3 == 'H')
                            FillTempGrid(tempFullGrid, a, k, result);

                        if ((k == 2 || k == 8) && result.Item3 == 'V')
                            FillTempGrid(tempFullGrid, a, k, result);
                    }

                    else if (indexSmallGrid == 8) //fill 78 rows and 03 col
                    {
                        if ((k == 6 || k == 7) && result.Item3 == 'H')
                            FillTempGrid(tempFullGrid, a, k, result);

                        if ((k == 2 || k == 5) && result.Item3 == 'V')
                            FillTempGrid(tempFullGrid, a, k, result);
                    }
                }
            }

            return CanIadd(tempFullGrid, numberToAdd, row, col);
        }

        private static int[,] DeepCopyGrid(int[,] grid)
        {
            int[,] tempFullGrid = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    tempFullGrid[i, j] = grid[i, j];
                }
            }

            return tempFullGrid;
        }

        private static List<int> SelectSubGrid(int indexSmallGrid)
        {
            List<int> smallGridToBeChecked = new List<int>();
            if (indexSmallGrid == 0)
            {
                smallGridToBeChecked.Add(1);
                smallGridToBeChecked.Add(2);
                smallGridToBeChecked.Add(3);
                smallGridToBeChecked.Add(6);
            }
            if (indexSmallGrid == 1)
            {
                smallGridToBeChecked.Add(0);
                smallGridToBeChecked.Add(2);
                smallGridToBeChecked.Add(4);
                smallGridToBeChecked.Add(7);
            }
            if (indexSmallGrid == 2)
            {
                smallGridToBeChecked.Add(0);
                smallGridToBeChecked.Add(1);
                smallGridToBeChecked.Add(5);
                smallGridToBeChecked.Add(8);
            }
            if (indexSmallGrid == 3)
            {
                smallGridToBeChecked.Add(0);
                smallGridToBeChecked.Add(6);
                smallGridToBeChecked.Add(4);
                smallGridToBeChecked.Add(5);
            }
            if (indexSmallGrid == 4)
            {
                smallGridToBeChecked.Add(1);
                smallGridToBeChecked.Add(7);
                smallGridToBeChecked.Add(3);
                smallGridToBeChecked.Add(5);
            }
            if (indexSmallGrid == 5)
            {
                smallGridToBeChecked.Add(2);
                smallGridToBeChecked.Add(8);
                smallGridToBeChecked.Add(3);
                smallGridToBeChecked.Add(4);
            }
            if (indexSmallGrid == 6)
            {
                smallGridToBeChecked.Add(0);
                smallGridToBeChecked.Add(3);
                smallGridToBeChecked.Add(7);
                smallGridToBeChecked.Add(8);
            }
            if (indexSmallGrid == 7)
            {
                smallGridToBeChecked.Add(1);
                smallGridToBeChecked.Add(4);
                smallGridToBeChecked.Add(6);
                smallGridToBeChecked.Add(8);
            }
            if (indexSmallGrid == 8)
            {
                smallGridToBeChecked.Add(2);
                smallGridToBeChecked.Add(5);
                smallGridToBeChecked.Add(6);
                smallGridToBeChecked.Add(7);
            }

            return smallGridToBeChecked;
        }

        private static void FillTempGrid(int[,] tempFullGrid, int[] a, int k, Tuple<bool, int[], char> result)
        {
            //find missing values in the subsquare (3x3) grid                    
            int[] b = GetSubSquare(k, tempFullGrid);
            var missingValues = a.Except(b).ToArray();

            int i = 0;

            //find coordinate
            foreach (var value in result.Item2)
            {
                var pippo = GetCoordinate(k, value);

                tempFullGrid[pippo.Item1, pippo.Item2] = missingValues[i];
                i++;
            }
        }

        /* return is:
         *  bool = found a 3x3 grid with missing up to 3 values in a single row or single col
         *  int[] = the index position where the missing values are located
         *  char = V or H to know if the missing value are in a col(v) or row(H)
         */
        public static Tuple<bool, int[], char> FreeRow(int k, int[,] x)
        {
            var subSquare = GetSubSquare(k, x);

            int[] r1 = { 0, 1, 2 };
            int[] r2 = { 3, 4, 5 };
            int[] r3 = { 6, 7, 8 };

            int[] c1 = { 0, 3, 6 };
            int[] c2 = { 1, 4, 7 };
            int[] c3 = { 2, 5, 8 };

            List<int[]> g = new List<int[]>();
            g.Add(r1);
            g.Add(r2);
            g.Add(r3);
            g.Add(c1);
            g.Add(c2);
            g.Add(c3);

            bool isSubSet = false;

            int nonZero = subSquare.Count(v => v != 0);
            if (nonZero > 5)
            {
                int[] indexOfZerosInSubArray = subSquare.Select((v, i) => v == 0 ? i : -1).Where(i => i != -1).ToArray();

                int indexList = 0; //0,1,2 are rows the other are col
                foreach (int[] item in g)
                {
                    isSubSet = !indexOfZerosInSubArray.Except(item).Any();
                    if (isSubSet)
                    {
                        if (indexList < 3)
                            return Tuple.Create(true, indexOfZerosInSubArray, 'H');
                        else
                            return Tuple.Create(true, indexOfZerosInSubArray, 'V');
                    }
                    indexList++;

                }
            }

            return Tuple.Create(false, new int[3], ' ');
        }

        //given subsquare and index find rows and col
        private static Tuple<int, int> GetCoordinate(int k, int index)
        {
            if (k == 0)
            {
                if (index == 0) return Tuple.Create(0, 0);
                if (index == 1) return Tuple.Create(0, 1);
                if (index == 2) return Tuple.Create(0, 2);
                if (index == 3) return Tuple.Create(1, 0);
                if (index == 4) return Tuple.Create(1, 1);
                if (index == 5) return Tuple.Create(1, 2);
                if (index == 6) return Tuple.Create(2, 0);
                if (index == 7) return Tuple.Create(2, 1);
                if (index == 8) return Tuple.Create(2, 2);

                throw new Exception("Fix this");
            }
            if (k == 1)
            {
                if (index == 0) return Tuple.Create(0, 3);
                if (index == 1) return Tuple.Create(0, 4);
                if (index == 2) return Tuple.Create(0, 5);
                if (index == 3) return Tuple.Create(1, 3);
                if (index == 4) return Tuple.Create(1, 4);
                if (index == 5) return Tuple.Create(1, 5);
                if (index == 6) return Tuple.Create(2, 3);
                if (index == 7) return Tuple.Create(2, 4);
                if (index == 8) return Tuple.Create(2, 5);
                throw new Exception("Fix this");

            }

            if (k == 2)
            {
                if (index == 0) return Tuple.Create(0, 6);
                if (index == 1) return Tuple.Create(0, 7);
                if (index == 2) return Tuple.Create(0, 8);
                if (index == 3) return Tuple.Create(1, 6);
                if (index == 4) return Tuple.Create(1, 7);
                if (index == 5) return Tuple.Create(1, 8);
                if (index == 6) return Tuple.Create(2, 6);
                if (index == 7) return Tuple.Create(2, 7);
                if (index == 8) return Tuple.Create(2, 8);
                throw new Exception("Fix this");

            }
            if (k == 3)
            {
                if (index == 0) return Tuple.Create(3, 0);
                if (index == 1) return Tuple.Create(3, 1);
                if (index == 2) return Tuple.Create(3, 2);
                if (index == 3) return Tuple.Create(4, 0);
                if (index == 4) return Tuple.Create(4, 1);
                if (index == 5) return Tuple.Create(4, 2);
                if (index == 6) return Tuple.Create(5, 0);
                if (index == 7) return Tuple.Create(5, 1);
                if (index == 8) return Tuple.Create(5, 2);
                throw new Exception("Fix this");

            }

            if (k == 4)
            {
                if (index == 0) return Tuple.Create(3, 3);
                if (index == 1) return Tuple.Create(3, 4);
                if (index == 2) return Tuple.Create(3, 5);
                if (index == 3) return Tuple.Create(4, 3);
                if (index == 4) return Tuple.Create(4, 4);
                if (index == 5) return Tuple.Create(4, 5);
                if (index == 6) return Tuple.Create(5, 3);
                if (index == 7) return Tuple.Create(5, 4);
                if (index == 8) return Tuple.Create(5, 5);
                throw new Exception("Fix this");

            }

            if (k == 5)
            {
                if (index == 0) return Tuple.Create(3, 6);
                if (index == 1) return Tuple.Create(3, 7);
                if (index == 2) return Tuple.Create(3, 8);
                if (index == 3) return Tuple.Create(4, 6);
                if (index == 4) return Tuple.Create(4, 7);
                if (index == 5) return Tuple.Create(4, 8);
                if (index == 6) return Tuple.Create(5, 6);
                if (index == 7) return Tuple.Create(5, 7);
                if (index == 8) return Tuple.Create(5, 8);
                throw new Exception("Fix this");

            }

            if (k == 6)
            {
                if (index == 0) return Tuple.Create(6, 0);
                if (index == 1) return Tuple.Create(6, 1);
                if (index == 2) return Tuple.Create(6, 2);
                if (index == 3) return Tuple.Create(7, 0);
                if (index == 4) return Tuple.Create(7, 1);
                if (index == 5) return Tuple.Create(7, 2);
                if (index == 6) return Tuple.Create(8, 0);
                if (index == 7) return Tuple.Create(8, 1);
                if (index == 8) return Tuple.Create(8, 2);
                throw new Exception("Fix this");

            }

            if (k == 7)
            {
                if (index == 0) return Tuple.Create(6, 3);
                if (index == 1) return Tuple.Create(6, 4);
                if (index == 2) return Tuple.Create(6, 5);
                if (index == 3) return Tuple.Create(7, 3);
                if (index == 4) return Tuple.Create(7, 4);
                if (index == 5) return Tuple.Create(7, 5);
                if (index == 6) return Tuple.Create(8, 3);
                if (index == 7) return Tuple.Create(8, 4);
                if (index == 8) return Tuple.Create(8, 5);
                throw new Exception("Fix this");

            }

            else
            {
                if (index == 0) return Tuple.Create(6, 6);
                if (index == 1) return Tuple.Create(6, 7);
                if (index == 2) return Tuple.Create(6, 8);
                if (index == 3) return Tuple.Create(7, 6);
                if (index == 4) return Tuple.Create(7, 7);
                if (index == 5) return Tuple.Create(7, 8);
                if (index == 6) return Tuple.Create(8, 6);
                if (index == 7) return Tuple.Create(8, 7);
                if (index == 8) return Tuple.Create(8, 8);
                throw new Exception("Fix this");

            }
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


    }
}
