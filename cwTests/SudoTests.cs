using Microsoft.VisualStudio.TestTools.UnitTesting;
using cw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw.Tests
{
    [TestClass()]
    public class SudoTests
    {
        [TestMethod()]
        public void SolveSudTest_7284942154_v1()
        {
            var initialGrid = SetInitialValues_7284942154_v1();
            var results = Sudo.SolveSud(initialGrid);

            Assert.IsTrue(Utils.CompareMultiDimArray(results, GetSolution_7284942154()));
        }

        [TestMethod()]
        public void SolveSudTest__7284942154_2()
        {
            var initialGrid = SetInitialValues_7284942154_v2();
            var results = Sudo.SolveSud(initialGrid);

            Assert.IsTrue(Utils.CompareMultiDimArray(results, GetSolution_7284942154()));
        }

        [TestMethod()]
        public void SolveSudTest_5559258325()
        {
            var initialGrid = SetInitialValues_5559258325();
            var results = Sudo.SolveSud(initialGrid);

            Assert.IsTrue(Utils.CompareMultiDimArray(results, GetSolution_5559258325()));
        }

        [TestMethod()]
        public void SolveSudTest_3238249354()
        {
            var initialGrid = SetInitialValues_3238249354();
            var results = Sudo.SolveSud(initialGrid);

            Assert.IsTrue(Utils.CompareMultiDimArray(results, GetSolution_3238249354()));
        }


        [TestMethod()]
        public void SolveSudTest_evil1()
        {
            var initialGrid = SetInitialValues_evil1();
            var results = Sudo.SolveSud(initialGrid);

            Assert.IsTrue(Utils.CompareMultiDimArray(results, GetSolution_evil()));
        }

        [TestMethod()]
        public void SolveSudTest_evil2()
        {
            var initialGrid = SetInitialValues_evil2();
            var results = Sudo.SolveSud(initialGrid);

            if (!IsGridCorrect(results))
                Assert.Fail();

        }
        //[TestMethod()]
        //public void SolveSudTest_empty()
        //{
        //    var initialGrid = SetInitialValues_empty();
        //    var results = Sudo.SolveSud(initialGrid);

        //    if (!IsGridCorrect(results))
        //        Assert.Fail();
        //}

        private static bool IsGridCorrect(int[,] results)
        {
            for (int i = 0; i < 9; i++)
            {
                if (Sudo.GetVerticalSlice(i, results).Sum() != 45)
                    return false;

                if (Sudo.GetHorizontalSlice(i, results).Sum() != 45)
                    return false;

                if (Sudo.GetSubSquare(i, results).Sum() != 45)
                    return false;
            }

            return true;
        }

        private static int[,] SetInitialValues_7284942154_v1()
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
                {   0,  0,  9,  1,  0,  5,  0,  8,  0,  },
                {   8,  0,  7,  6,  9,  3,  1,  0,  0,  },
                {   0,  5,  0,  8,  0,  4,  0,  6,  0,  },
                {   0,  0,  3,  2,  1,  8,  6,  5,  0,  },
                {   2,  0,  0,  5,  4,  7,  8,  0,  3,  },
                {   0,  8,  5,  9,  3,  6,  4,  0,  0,  },
                {   0,  7,  0,  4,  0,  1,  9,  3,  6,  },
                {   0,  0,  0,  3,  6,  2,  5,  7,  8,  },
                {   0,  0,  0,  7,  0,  9,  2,  0,  0,  },
            });

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }
            return x;
        }

        private static int[,] SetInitialValues_7284942154_v2()
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
                {   0,  0,  9,  1,  0,  0,  0,  0,  0,  },
                {   8,  0,  7,  0,  9,  3,  0,  0,  0,  },
                {   0,  5,  0,  8,  0,  0,  0,  6,  0,  },
                {   0,  0,  3,  0,  1,  8,  6,  5,  0,  },
                {   2,  0,  0,  5,  0,  7,  0,  0,  3,  },
                {   0,  8,  5,  9,  3,  0,  4,  0,  0,  },
                {   0,  7,  0,  0,  0,  1,  0,  3,  0,  },
                {   0,  0,  0,  3,  6,  0,  5,  0,  8,  },
                {   0,  0,  0,  0,  0,  9,  2,  0,  0,  },
            });

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }
            return x;
        }

        private static int[,] SetInitialValues_5559258325()
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
            { 0, 5, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 1, 0, 0, 3, 0, 0, 8, 0 },
            { 0, 7, 8, 0, 4, 0, 6, 5, 0 },
            { 0, 4, 0, 1, 0, 0, 0, 0, 5 },
            { 0, 0, 7, 0, 8, 0, 3, 0, 0 },
            { 3, 0, 0, 0, 0, 9, 0, 2, 0 },
            { 0, 8, 4, 0, 6, 0, 5, 3, 0 },
            { 0, 2, 0, 0, 1, 0, 0, 9, 8 },
            { 0, 0, 0, 0, 0, 0, 0, 4, 0 },
            });



            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }
            return x;
        }

        private static int[,] SetInitialValues_3238249354()
        {
            int[,] x = new int[9, 9];
            List<int[]> grid = new List<int[]>();

            grid.Add(new int[] { 0, 9, 0, 1, 0, 0, 0, 0, 4 });
            grid.Add(new int[] { 0, 0, 5, 0, 6, 0, 0, 0, 3 });
            grid.Add(new int[] { 3, 0, 0, 0, 0, 5, 0, 0, 0 });
            grid.Add(new int[] { 0, 8, 2, 0, 0, 0, 4, 0, 5 });
            grid.Add(new int[] { 0, 7, 0, 0, 0, 0, 0, 8, 0 });
            grid.Add(new int[] { 1, 0, 6, 0, 0, 0, 3, 7, 0 });
            grid.Add(new int[] { 0, 0, 0, 7, 0, 0, 0, 0, 8 });
            grid.Add(new int[] { 8, 0, 0, 0, 4, 0, 5, 0, 0 });
            grid.Add(new int[] { 2, 0, 0, 0, 0, 9, 0, 6, 0 });

            for (int i = 0; i < 9; i++)
            {
                var pippo = grid.ElementAt(i);
                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = pippo[j];
                }
            }

            return x;
        }

        private static int[,] SetInitialValues_evil1()
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
                {   6,  0,  0,  0,  5,  0,  2,  0,  0,  },
                {   0,  0,  0,  9,  0,  0,  7,  0,  0,  },
                {   1,  0,  0,  0,  0,  3,  0,  0,  0,  },
                {   0,  0,  2,  0,  0,  6,  5,  4,  0,  },
                {   9,  0,  0,  0,  0,  0,  0,  0,  3,  },
                {   0,  4,  3,  7,  0,  0,  9,  0,  0,  },
                {   0,  0,  0,  2,  0,  0,  0,  0,  9,  },
                {   0,  0,  5,  0,  0,  4,  0,  0,  0,  },
                {   0,  0,  7,  0,  8,  0,  0,  0,  4,  },  //by removing the 8 in position (8,4) it is not able to solve it
                });

            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }

            return x;
        }

        private static int[,] SetInitialValues_evil2()
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
                {   6,  0,  0,  0,  5,  0,  2,  0,  0,  },
                {   0,  0,  0,  9,  0,  0,  7,  0,  0,  },
                {   1,  0,  0,  0,  0,  3,  0,  0,  0,  },
                {   0,  0,  2,  0,  0,  6,  5,  4,  0,  },
                {   9,  0,  0,  0,  0,  0,  0,  0,  3,  },
                {   0,  4,  3,  7,  0,  0,  9,  0,  0,  },
                {   0,  0,  0,  2,  0,  0,  0,  0,  9,  },
                {   0,  0,  5,  0,  0,  4,  0,  0,  0,  },
                {   0,  0,  7,  0,  0,  0,  0,  0,  4,  },  //by removing the 8 in position (8,4) it is not able to solve it
                });

            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }

            return x;
        }

        private static int[,] SetInitialValues_empty()
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  },
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  },
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  },
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  },
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  },
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  },
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  },
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  },
                {   0,  0,  0,  0,  0,  0,  0,  0,  0,  },
                });

            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }

            return x;
        }


        private static int[,] GetSolution_5559258325()
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
                {   2,  5,  3,  8,  9,  6,  4,  7,  1,  },
                {   4,  1,  6,  7,  3,  5,  2,  8,  9,  },
                {   9,  7,  8,  2,  4,  1,  6,  5,  3,  },
                {   8,  4,  2,  1,  7,  3,  9,  6,  5,  },
                {   5,  9,  7,  6,  8,  2,  3,  1,  4,  },
                {   3,  6,  1,  4,  5,  9,  8,  2,  7,  },
                {   1,  8,  4,  9,  6,  7,  5,  3,  2,  },
                {   6,  2,  5,  3,  1,  4,  7,  9,  8,  },
                {   7,  3,  9,  5,  2,  8,  1,  4,  6,  },
            });

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }
            return x;

        }

        private static int[,] GetSolution_7284942154()
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
               {    4,  6,  9,  1,  7,  5,  3,  8,  2,  },
               {    8,  2,  7,  6,  9,  3,  1,  4,  5,  },
               {    3,  5,  1,  8,  2,  4,  7,  6,  9,  },
               {    9,  4,  3,  2,  1,  8,  6,  5,  7,  },
               {    2,  1,  6,  5,  4,  7,  8,  9,  3,  },
               {    7,  8,  5,  9,  3,  6,  4,  2,  1,  },
               {    5,  7,  2,  4,  8,  1,  9,  3,  6,  },
               {    1,  9,  4,  3,  6,  2,  5,  7,  8,  },
               {    6,  3,  8,  7,  5,  9,  2,  1,  4,  },
            });

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }
            return x;

        }

        private static int[,] GetSolution_3238249354()
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
                {   7,  9,  8,  1,  2,  3,  6,  5,  4,  },
                {   4,  2,  5,  8,  6,  7,  1,  9,  3,  },
                {   3,  6,  1,  4,  9,  5,  8,  2,  7,  },
                {   9,  8,  2,  3,  7,  6,  4,  1,  5,  },
                {   5,  7,  3,  2,  1,  4,  9,  8,  6,  },
                {   1,  4,  6,  9,  5,  8,  3,  7,  2,  },
                {   6,  5,  9,  7,  3,  1,  2,  4,  8,  },
                {   8,  1,  7,  6,  4,  2,  5,  3,  9,  },
                {   2,  3,  4,  5,  8,  9,  7,  6,  1,  },
            });

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }
            return x;

        }

        private static int[,] GetSolution_evil()  //this is one solution - evil can have more than one solution
        {
            int[,] x = new int[9, 9];

            List<int[,]> grid2 = new List<int[,]>();

            grid2.Add(new int[,] {
                {   6,  7,  9,  4,  5,  8,  2,  3,  1,  },
                {   5,  3,  4,  9,  2,  1,  7,  8,  6,  },
                {   1,  2,  8,  6,  7,  3,  4,  9,  5,  },
                {   7,  1,  2,  3,  9,  6,  5,  4,  8,  },
                {   9,  5,  6,  8,  4,  2,  1,  7,  3,  },
                {   8,  4,  3,  7,  1,  5,  9,  6,  2,  },
                {   4,  8,  1,  2,  3,  7,  6,  5,  9,  },
                {   3,  9,  5,  1,  6,  4,  8,  2,  7,  },
                {   2,  6,  7,  5,  8,  9,  3,  1,  4,  },
            });

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    x[i, j] = grid2.ElementAt(0)[i, j];
                }
            }
            return x;
        }

    }
}