using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4.Logic;

namespace Task4.Logic.Test
{
    [TestClass]
    public class ExtensionToolsForArrayTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] testArray0 = new int[50];
            int[] rstExpected0 = new int[50];
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                int a = rand.Next(-100, 100);
                testArray0[i] = a;
                rstExpected0[i] = a;
            }
            Array.Sort(rstExpected0);
            testArray0.MergeSort(new ExtensionToolsForArray.IncComparer<int>());
            int[] testArray1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] testArray2 = new int[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0 };
            int[] rstExpected1 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] rstExpected2 = new int[] { 0, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
            testArray1.MergeSort(new ExtensionToolsForArray.IncComparer<int>());
            testArray2.MergeSort(new ExtensionToolsForArray.DecComparer<int>());
            CollectionAssert.AreEqual(rstExpected2, testArray2);
            CollectionAssert.AreEqual(rstExpected1,testArray1);
            CollectionAssert.AreEqual(rstExpected0, testArray0);
        }

    }
}
