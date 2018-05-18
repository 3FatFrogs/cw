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
    public class SortingTests
    {
        [TestInitialize]
        public void Initialize()
        {
            iData = new int[901];
            InitializeIntArray(iData);

            oData = iData.OrderBy(x => x).ToArray();
        }

        public int[] iData { get; set; }
        public int[] oData { get; set; }

        private void InitializeIntArray(int[] x)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < x.Length; i++)
            {
                x[i] = rand.Next();
            }
        }

        [TestMethod()]
        public void BubbleSortTest()
        {
            Sorting.BubbleSort(iData);
            Assert.IsTrue(Enumerable.SequenceEqual(iData, oData));
        }

        [TestMethod()]
        public void SelectionSortTest()
        {
            Sorting.SelectionSort(iData);
            Assert.IsTrue(Enumerable.SequenceEqual(iData, oData));
        }

        [TestMethod()]
        public void InsertionSortTest()
        {
            Sorting.InsertionSort(iData);
            Assert.IsTrue(Enumerable.SequenceEqual(iData, oData));
        }

        [TestMethod()]
        public void ShellSortTest()
        {
            List<int> gaps = new List<int>();
            gaps.Add(1 + iData.Length / 2);
            gaps.Add(701);
            gaps.Add(53);
            gaps.Add(23);
            gaps.Add(1);

            Sorting.ShellSort(iData, gaps);
            Assert.IsTrue(Enumerable.SequenceEqual(iData, oData));
        }

        [TestMethod()]
        public void QuickSortTest()
        {
            Sorting.QuickSort(iData, 0, iData.Length - 1);
            Assert.IsTrue(Enumerable.SequenceEqual(iData, oData));

        }
    }
}