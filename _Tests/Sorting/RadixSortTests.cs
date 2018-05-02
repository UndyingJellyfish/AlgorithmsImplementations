using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithms;

namespace _Tests.Sorting
{
    [TestClass]
    public class UnitTestRadix
    {
        [TestMethod]
        public void TestSortingInts()
        {
            List<int> ints = new List<int>{ 3,5,1,8,2 };
            ints = RadixSort.Sort(ints);
            var expected = new List<int> {1, 2, 3, 5, 8};
            Assert.AreEqual(expected.Count, ints.Count);
            for (int i = 0; i < ints.Count; i++)
            {
                Assert.AreEqual(expected[i], ints[i]);
            }
        }
    }
}
