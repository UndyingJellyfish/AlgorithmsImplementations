using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace _Tests.Sorting
{
    [TestClass]
    public class UnitTestRadix
    {
        [TestMethod]
        public void TestSortingIntsNonGeneric()
        {
            var ints = new List<int>{ 3,5,1,8,2 };
            ints = RadixSort.Sort(ints);
            var expected = new List<int> {1, 2, 3, 5, 8};
            Assert.AreEqual(expected.Count, ints.Count);
            for (int i = 0; i < ints.Count; i++)
            {
                Assert.AreEqual(expected[i], ints[i]);
            }
        }

        [TestMethod]
        public void TestSortingIntsGeneric()
        {
            var ints = new List<int> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<int>(new Int32.Calculator());
            ints = radixSort.Sort(ints);
            var expected = new List<int> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, ints.Count);
            for (int i = 0; i < ints.Count; i++)
            {
                Assert.AreEqual(expected[i], ints[i]);
            }
        }
        [TestMethod]
        public void TestSortingLongsGeneric()
        {
            var longs = new List<long> { 3L, 5L, 1L, 8L, 2L };
            var radixSort = new RadixSort<long>(new Long.Calculator());
            longs = radixSort.Sort(longs);
            var expected = new List<long> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, longs.Count);
            for (int i = 0; i < longs.Count; i++)
            {
                Assert.AreEqual(expected[i], longs[i]);
            }
        }
        [TestMethod]
        public void TestSortingBytesGeneric()
        {
            var bytes = new List<byte> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<byte>(new Byte.Calculator());
            bytes = radixSort.Sort(bytes);
            var expected = new List<byte> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, bytes.Count);
            for (int i = 0; i < bytes.Count; i++)
            {
                Assert.AreEqual(expected[i], bytes[i]);
            }
        }
        [TestMethod]
        public void TestSortingShortsGeneric()
        {
            var shorts = new List<short> { 3, 5, 1, 8, 2 };
            var radixSort = new RadixSort<short>(new Short.Calculator());
            shorts = radixSort.Sort(shorts);
            var expected = new List<short> { 1, 2, 3, 5, 8 };
            Assert.AreEqual(expected.Count, shorts.Count);
            for (int i = 0; i < shorts.Count; i++)
            {
                Assert.AreEqual(expected[i], shorts[i]);
            }
        }

    }
}
