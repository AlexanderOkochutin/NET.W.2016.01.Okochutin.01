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
            int[] testArray1 = new int[50];
            int[] rstExpected0 = new int[50];
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                int a = rand.Next(-100, 100);
                testArray0[i] = a;
                testArray1[i] = a;
                rstExpected0[i] = a;
            }
            Array.Sort(rstExpected0);
            testArray0.MergeSort(new ExtensionToolsForArray.IncComparer<int>());
            CollectionAssert.AreEqual(rstExpected0, testArray0);
            Array.Reverse(rstExpected0);
            testArray1.MergeSort(new ExtensionToolsForArray.DecComparer<int>());
            CollectionAssert.AreEqual(rstExpected0, testArray1);
        }

    }
}
